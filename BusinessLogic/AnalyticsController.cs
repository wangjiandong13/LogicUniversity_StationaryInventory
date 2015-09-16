using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace BusinessLogic
{

    public class AnalyticsController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// Get Reports
        /// </summary>
        /// <returns>Report List</returns>
        public List<Report> getReports()
        {
            List<Report> reportList = ctx.Report.ToList();
            return reportList;
        }

        /// <summary>
        /// Update Report
        /// </summary>
        /// <param name="rp">Report Object</param>
        /// <returns>bool result</returns>
        public bool updateReport(Report rp)
        {
            bool result = true;
            Report results = new Report();

            // save report remarks and title in db
            Report rpt = ctx.Report.Where(x => x.ReportID == rp.ReportID).FirstOrDefault();
            rpt.Title = rp.Title;
            rpt.Remark = rp.Remark;

            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Generate New Report
        /// </summary>
        /// <param name="rp">Report Object</param>
        /// <returns>String reportID</returns>
        public string generateNewReport(Report rp)
        {
            string resultID = "";

            // save report settings in db
            DateTime sdate = Convert.ToDateTime(rp.StartD);
            DateTime edate = Convert.ToDateTime(rp.EndD);

            Report rpt = new Report();
            rpt.Date = DateTime.Today;
            rpt.EmpID = rp.EmpID;
            rpt.Title = rp.Title;
            rpt.StartD = sdate;
            rpt.EndD = edate;
            rpt.Remark = rp.Remark;
            rpt.Type = rp.Type;
            rpt.Criteria = rp.Criteria;
            rpt.Precriteria = rp.Precriteria;
            ctx.Report.Add(rpt);

            bool saveInDb = true;
            try
            {
                ctx.SaveChanges();
            }
            catch
            {
                saveInDb = false;
            }

            if (saveInDb == true)
            {
                Report reportGenerated = ctx.Report.ToList().Last();
                string reportID = reportGenerated.ReportID.ToString();
                resultID = reportID;

                //send notification
                NotificationController nc = new NotificationController();
                nc.sendNotification(15, 0, reportID);
            }

            return resultID;
        }

        /// <summary>
        /// Generate Existing Report
        /// </summary>
        /// <param name="reportID">string reportID </param>
        /// <returns> List<ReportResult> object</returns>
        public List<ReportResult> generateExistingReport(string id)
        {
            int reportID = Int32.Parse(id);
            //get report settings from db
            Report rp = ctx.Report.Where(x => x.ReportID == reportID).FirstOrDefault();

            List<ReportResult> results = new List<ReportResult>();
            DateTime sdate = (DateTime)rp.StartD;
            DateTime edate = (DateTime)rp.EndD;
            int monthsNo = (((edate.Year - sdate.Year) * 12) + edate.Month - sdate.Month) + 1;
            int type = Convert.ToInt32(rp.Type);
            int criteria = Convert.ToInt32(rp.Criteria);
            int precriteria = Convert.ToInt32(rp.Precriteria);

            //fetch results
            switch (type)
            {
                //Total no. of Requisitions
                case 1:
                    {
                        var requisitions = ctx.RequisitionAnalytics.Where(x => x.Date >= sdate && x.Date <= edate).ToList();

                        // qty of all dept requests shown:
                        if (precriteria == 0)
                        {
                            List<Department> dept = ctx.Department.ToList();

                            for (int m = 0; m < monthsNo; m++)
                            {
                                int month = sdate.Month + m;
                                int year = sdate.Year;
                                if (month - 12 > 0)
                                {
                                    month = month - 12;
                                    year = year + 1;
                                }
                                ReportResult r = new ReportResult();
                                r.MonthYear = String.Format("{0}/{1}", month, year);
                                r.ReportItems = new List<ReportResultItems>();
                                //create each result item per dept id
                                for (int d = 0; d < dept.Count; d++)
                                {
                                    ReportResultItems ri = new ReportResultItems();
                                    ri.Subject = dept[d].DeptID;
                                    r.ReportItems.Add(ri);
                                }

                                //get req by dept id in each month
                                List<int> reqIdChecked = new List<int>();
                                for (int i = 0; i < requisitions.Count; i++)
                                {
                                    //check if same requisition as rows retrieved are individual items in each req
                                    bool sameReq = false;
                                    if (reqIdChecked.Count > 0)
                                    {
                                        for (int j = 0; j < reqIdChecked.Count; j++)
                                        {
                                            if (requisitions[i].ReqID == reqIdChecked[j])
                                            {
                                                sameReq = true;
                                                for (int d = 0; d < dept.Count; d++)
                                                {
                                                    if (requisitions[i].DeptID.Equals(dept[d].DeptID))
                                                    {
                                                        int qty = Convert.ToInt32(requisitions[i].IssueQty);
                                                        double price = Convert.ToDouble(requisitions[i].Price);
                                                        r.ReportItems.ToList()[d].Price += (qty * price);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }

                                    if (sameReq == false)
                                    {
                                        //add req to result
                                        int reqMonth = Convert.ToDateTime(requisitions[i].Date).Month;
                                        if (reqMonth == month)
                                        {
                                            for (int d = 0; d < dept.Count; d++)
                                            {
                                                if (requisitions[i].DeptID.Equals(dept[d].DeptID))
                                                {
                                                    int qty = Convert.ToInt32(requisitions[i].IssueQty);
                                                    double price = Convert.ToDouble(requisitions[i].Price);
                                                    r.ReportItems.ToList()[d].Price += (qty * price);
                                                    r.ReportItems.ToList()[d].Qty++;
                                                    break;
                                                }
                                            }
                                        }
                                        reqIdChecked.Add(requisitions[i].ReqID);
                                    }
                                }
                                results.Add(r);
                            }
                        }
                        break;
                    }


                //Total no. of Requisition Items
                case 2:
                    {
                        //view all depts for each item category selected
                        if (precriteria == 0)
                        {
                            var requisitions = new List<RequisitionAnalytics>();
                            if (criteria > 0)
                            {
                                requisitions = ctx.RequisitionAnalytics.Where(x => x.Date >= sdate && x.Date <= edate && x.ItemCatID == criteria).ToList();
                            }
                            else if (criteria == 0)
                            {
                                requisitions = ctx.RequisitionAnalytics.Where(x => x.Date >= sdate && x.Date <= edate).ToList();
                            }

                            List<Department> dept = ctx.Department.ToList();

                            for (int m = 0; m < monthsNo; m++)
                            {
                                int month = sdate.Month + m;
                                int year = sdate.Year;
                                if (month - 12 > 0)
                                {
                                    month = month - 12;
                                    year = year + 1;
                                }
                                ReportResult r = new ReportResult();
                                r.MonthYear = String.Format("{0}/{1}", month, year);
                                r.ReportItems = new List<ReportResultItems>();

                                //create each result item per item category
                                for (int c = 0; c < dept.Count; c++)
                                {
                                    ReportResultItems ri = new ReportResultItems();
                                    ri.Subject = dept[c].DeptID;
                                    r.ReportItems.Add(ri);
                                }

                                //get all req items in each month
                                for (int i = 0; i < requisitions.Count; i++)
                                {
                                    int reqMonth = Convert.ToDateTime(requisitions[i].Date).Month;
                                    if (reqMonth == month)
                                    {
                                        //get by item cat
                                        for (int c = 0; c < dept.Count; c++)
                                        {
                                            if (requisitions[i].DeptID == dept[c].DeptID)
                                            {
                                                //add req item to result
                                                int qty = Convert.ToInt32(requisitions[i].RequestQty);
                                                int Issqty = Convert.ToInt32(requisitions[i].IssueQty);
                                                double price = Convert.ToDouble(requisitions[i].Price);
                                                r.ReportItems.ToList()[c].Qty += qty;
                                                r.ReportItems.ToList()[c].Price += (Issqty * price);
                                                break;
                                            }
                                        }
                                    }
                                }
                                results.Add(r);
                            }
                        }

                        //view all item categories
                        else if (precriteria == 1)
                        {

                            var requisitions = ctx.RequisitionAnalytics.Where(x => x.Date >= sdate && x.Date <= edate).ToList();
                            List<ItemCategory> itemCat = ctx.ItemCategory.ToList();

                            //view all
                            if (criteria == 0)
                            {
                                for (int m = 0; m < monthsNo; m++)
                                {
                                    int month = sdate.Month + m;
                                    int year = sdate.Year;
                                    if (month - 12 > 0)
                                    {
                                        month = month - 12;
                                        year = year + 1;
                                    }
                                    ReportResult r = new ReportResult();
                                    r.MonthYear = String.Format("{0}/{1}", month, year);
                                    r.ReportItems = new List<ReportResultItems>();

                                    //create each result item per item category
                                    for (int c = 0; c < itemCat.Count; c++)
                                    {
                                        ReportResultItems ri = new ReportResultItems();
                                        ri.Subject = itemCat[c].ItemDescription;
                                        r.ReportItems.Add(ri);
                                    }

                                    //get all req items in each month
                                    for (int i = 0; i < requisitions.Count; i++)
                                    {
                                        int reqMonth = Convert.ToDateTime(requisitions[i].Date).Month;
                                        if (reqMonth == month)
                                        {
                                            int category = Convert.ToInt32(requisitions[i].ItemCatID);
                                            //get by item cat
                                            for (int c = 0; c < itemCat.Count; c++)
                                            {
                                                if (category == itemCat[c].ItemCatID)
                                                {
                                                    //add req item to result
                                                    int qty = Convert.ToInt32(requisitions[i].RequestQty);
                                                    int Issqty = Convert.ToInt32(requisitions[i].IssueQty);
                                                    double price = Convert.ToDouble(requisitions[i].Price);
                                                    r.ReportItems.ToList()[c].Qty += qty;
                                                    r.ReportItems.ToList()[c].Price += (Issqty * price);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    results.Add(r);
                                }
                            }

                            //view items of 1 department selected
                            else if (criteria > 0)
                            {
                                List<Department> dept = ctx.Department.ToList();

                                for (int m = 0; m < monthsNo; m++)
                                {
                                    int month = sdate.Month + m;
                                    int year = sdate.Year;
                                    if (month - 12 > 0)
                                    {
                                        month = month - 12;
                                        year = year + 1;
                                    }
                                    ReportResult r = new ReportResult();
                                    r.MonthYear = String.Format("{0}/{1}", month, year);
                                    r.ReportItems = new List<ReportResultItems>();

                                    //create each result item per item category
                                    for (int c = 0; c < itemCat.Count; c++)
                                    {
                                        ReportResultItems ri = new ReportResultItems();
                                        ri.Subject = itemCat[c].ItemDescription;
                                        r.ReportItems.Add(ri);
                                    }

                                    int deptPos = criteria - 1;

                                    //get all req items in each month
                                    for (int i = 0; i < requisitions.Count; i++)
                                    {
                                        int reqMonth = Convert.ToDateTime(requisitions[i].Date).Month;
                                        if (reqMonth == month && requisitions[i].DeptID == dept[deptPos].DeptID)
                                        {
                                            int category = Convert.ToInt32(requisitions[i].ItemCatID);
                                            //get by item cat
                                            for (int c = 0; c < itemCat.Count; c++)
                                            {
                                                if (category == itemCat[c].ItemCatID)
                                                {
                                                    //add req item to result
                                                    int qty = Convert.ToInt32(requisitions[i].RequestQty);
                                                    int Issqty = Convert.ToInt32(requisitions[i].IssueQty);
                                                    double price = Convert.ToDouble(requisitions[i].Price);
                                                    r.ReportItems.ToList()[c].Qty += qty;
                                                    r.ReportItems.ToList()[c].Price += (Issqty * price);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    results.Add(r);
                                }
                            }
                        }
                        break;
                    }


                //Total no. of Purchase Orders
                case 3:
                    {
                        var reorders = ctx.ReorderAnalytics.Where(x => x.Date >= sdate && x.Date <= edate).ToList();

                        // qty of purchase orders to all SupplierIDs must be shown
                        if (precriteria == 2)
                        {
                            List<Supplier> sup = ctx.Supplier.Where(x => x.Rank < 4).ToList();

                            for (int m = 0; m < monthsNo; m++)
                            {
                                int month = sdate.Month + m;
                                int year = sdate.Year;
                                if (month - 12 > 0)
                                {
                                    month = month - 12;
                                    year = year + 1;
                                }
                                ReportResult r = new ReportResult();
                                r.MonthYear = String.Format("{0}/{1}", month, year);
                                r.ReportItems = new List<ReportResultItems>();
                                //create each result item per dept id
                                for (int d = 0; d < sup.Count; d++)
                                {
                                    ReportResultItems ri = new ReportResultItems();
                                    ri.Subject = sup[d].SupplierID;
                                    r.ReportItems.Add(ri);
                                }

                                //get all purchase orders in each month
                                List<int> reqIdChecked = new List<int>();
                                for (int i = 0; i < reorders.Count; i++)
                                {
                                    //check if same purchase orders as rows retrieved are individual items in each req
                                    bool sameReq = false;
                                    if (reqIdChecked.Count > 0)
                                    {
                                        for (int j = 0; j < reqIdChecked.Count; j++)
                                        {
                                            if (reorders[i].PoID == reqIdChecked[j])
                                            {
                                                sameReq = true;
                                                for (int d = 0; d < sup.Count; d++)
                                                {
                                                    if (reorders[i].SupplierID.Equals(sup[d].SupplierID))
                                                    {
                                                        int qty = Convert.ToInt32(reorders[i].ActualQty);
                                                        double price = Convert.ToDouble(reorders[i].Price);
                                                        r.ReportItems.ToList()[d].Price += (qty * price);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }

                                    if (sameReq == false)
                                    {
                                        //add PO to result
                                        int reqMonth = Convert.ToDateTime(reorders[i].Date).Month;
                                        if (reqMonth == month)
                                        {
                                            for (int d = 0; d < sup.Count; d++)
                                            {
                                                if (reorders[i].SupplierID.Equals(sup[d].SupplierID))
                                                {
                                                    int qty = Convert.ToInt32(reorders[i].ActualQty);
                                                    double price = Convert.ToDouble(reorders[i].Price);
                                                    r.ReportItems.ToList()[d].Price += (qty * price);
                                                    r.ReportItems.ToList()[d].Qty++;
                                                    break;
                                                }
                                            }
                                        }
                                        reqIdChecked.Add(reorders[i].PoID);
                                    }
                                }
                                results.Add(r);
                            }
                        }
                        break;
                    }


                //Total no. of reorder Items
                case 4:
                    {
                        //view all suppliers for each item category selected
                        if (precriteria == 2)
                        {
                            var reorders = new List<ReorderAnalytics>();
                            if (criteria > 0)
                            {
                                reorders = ctx.ReorderAnalytics.Where(x => x.Date >= sdate && x.Date <= edate && x.ItemCatID == criteria).ToList();
                            }
                            else if (criteria == 0)
                            {
                                reorders = ctx.ReorderAnalytics.Where(x => x.Date >= sdate && x.Date <= edate).ToList();
                            }

                            List<Supplier> sup = ctx.Supplier.ToList();

                            for (int m = 0; m < monthsNo; m++)
                            {
                                int month = sdate.Month + m;
                                int year = sdate.Year;
                                if (month - 12 > 0)
                                {
                                    month = month - 12;
                                    year = year + 1;
                                }
                                ReportResult r = new ReportResult();
                                r.MonthYear = String.Format("{0}/{1}", month, year);
                                r.ReportItems = new List<ReportResultItems>();

                                //create each result item per item category
                                for (int c = 0; c < sup.Count; c++)
                                {
                                    ReportResultItems ri = new ReportResultItems();
                                    ri.Subject = sup[c].SupplierID;
                                    r.ReportItems.Add(ri);
                                }

                                //get all req items in each month
                                for (int i = 0; i < reorders.Count; i++)
                                {
                                    int reqMonth = Convert.ToDateTime(reorders[i].Date).Month;
                                    if (reqMonth == month)
                                    {
                                        //get by item cat
                                        for (int c = 0; c < sup.Count; c++)
                                        {
                                            if (reorders[i].SupplierID == sup[c].SupplierID)
                                            {
                                                //add req item to result
                                                int qty = Convert.ToInt32(reorders[i].Qty);
                                                int Aqty = Convert.ToInt32(reorders[i].ActualQty);
                                                double price = Convert.ToDouble(reorders[i].Price);
                                                r.ReportItems.ToList()[c].Qty += qty;
                                                r.ReportItems.ToList()[c].Price += (Aqty * price);
                                                break;
                                            }
                                        }
                                    }
                                }
                                results.Add(r);
                            }
                        }

                        //view all item categories
                        else if (precriteria == 1)
                        {
                            var reorders = ctx.ReorderAnalytics.Where(x => x.Date >= sdate && x.Date <= edate).ToList();
                            List<ItemCategory> itemCat = ctx.ItemCategory.ToList();

                            //all item categories
                            if (criteria == 0)
                            {
                                for (int m = 0; m < monthsNo; m++)
                                {
                                    int month = sdate.Month + m;
                                    int year = sdate.Year;
                                    if (month - 12 > 0)
                                    {
                                        month = month - 12;
                                        year = year + 1;
                                    }
                                    ReportResult r = new ReportResult();
                                    r.MonthYear = String.Format("{0}/{1}", month, year);
                                    r.ReportItems = new List<ReportResultItems>();

                                    //create each result item per item category
                                    for (int c = 0; c < itemCat.Count; c++)
                                    {
                                        ReportResultItems ri = new ReportResultItems();
                                        ri.Subject = itemCat[c].ItemDescription;
                                        r.ReportItems.Add(ri);
                                    }

                                    //get all reorder items in each month
                                    for (int i = 0; i < reorders.Count; i++)
                                    {
                                        int reqMonth = Convert.ToDateTime(reorders[i].Date).Month;
                                        if (reqMonth == month)
                                        {
                                            int category = Convert.ToInt32(reorders[i].ItemCatID);
                                            //get by item cat
                                            for (int c = 0; c < itemCat.Count; c++)
                                            {
                                                if (category == itemCat[c].ItemCatID)
                                                {
                                                    //add reorder item to result
                                                    int qty = Convert.ToInt32(reorders[i].Qty);
                                                    int Aqty = Convert.ToInt32(reorders[i].ActualQty);
                                                    double price = Convert.ToDouble(reorders[i].Price);
                                                    r.ReportItems.ToList()[c].Qty += qty;
                                                    r.ReportItems.ToList()[c].Price += (Aqty * price);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    results.Add(r);
                                }
                            }

                            //by supplier rank selected
                            else if (criteria > 0)
                            {
                                Supplier sup = ctx.Supplier.Where(x => x.Rank == criteria).FirstOrDefault();

                                for (int m = 0; m < monthsNo; m++)
                                {
                                    int month = sdate.Month + m;
                                    int year = sdate.Year;
                                    if (month - 12 > 0)
                                    {
                                        month = month - 12;
                                        year = year + 1;
                                    }
                                    ReportResult r = new ReportResult();
                                    r.MonthYear = String.Format("{0}/{1}", month, year);
                                    r.ReportItems = new List<ReportResultItems>();

                                    //create each result item per item category
                                    for (int c = 0; c < itemCat.Count; c++)
                                    {
                                        ReportResultItems ri = new ReportResultItems();
                                        ri.Subject = itemCat[c].ItemDescription;
                                        r.ReportItems.Add(ri);
                                    }

                                    //get all reorder items in each month
                                    for (int i = 0; i < reorders.Count; i++)
                                    {
                                        int reqMonth = Convert.ToDateTime(reorders[i].Date).Month;
                                        if (reqMonth == month && reorders[i].SupplierID.Equals(sup.SupplierID))
                                        {
                                            int category = Convert.ToInt32(reorders[i].ItemCatID);
                                            //get by item cat
                                            for (int c = 0; c < itemCat.Count; c++)
                                            {
                                                if (category == itemCat[c].ItemCatID)
                                                {
                                                    //add reorder item to result
                                                    int qty = Convert.ToInt32(reorders[i].Qty);
                                                    int Aqty = Convert.ToInt32(reorders[i].ActualQty);
                                                    double price = Convert.ToDouble(reorders[i].Price);
                                                    r.ReportItems.ToList()[c].Qty += qty;
                                                    r.ReportItems.ToList()[c].Price += (Aqty * price);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    results.Add(r);
                                }
                            }
                        }
                        break;
                    }
            }

            return results;
        }

        public List<ReportResult> generateExistingReportStyle2(string reportID)
        {

            List<ReportResult> input = generateExistingReport(reportID);

            // codes to swap subject and monthyear in results (for web display purpose)
            List<ReportResult> newReportResult = new List<ReportResult>();
            List<String> subjects = new List<String>();
            List<String> monthYears = new List<String>();

            for (int j = 0; j < input[0].ReportItems.Count; j++)
            {
                subjects.Add(input[0].ReportItems.ToList()[j].Subject);
                ReportResult r = new ReportResult();
                r.MonthYear = input[0].ReportItems.ToList()[j].Subject;
                r.ReportItems = new List<ReportResultItems>();
                newReportResult.Add(r);
            }

            for (int i = 0; i < input.Count; i++)
            {
                List<ReportResultItems> reportItems = input[i].ReportItems.ToList();

                for (int j = 0; j < reportItems.Count; j++)
                {
                    //mth year price qty items
                    ReportResultItems ri = new ReportResultItems();
                    ri.Subject = input[i].MonthYear;
                    ri.Price = reportItems[j].Price;
                    ri.Qty = reportItems[j].Qty;

                    newReportResult[j].ReportItems.Add(ri);
                }
            }

            return newReportResult;
        }
    }
}
