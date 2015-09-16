using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Net;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace BusinessLogic
{
    public class NotificationController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// CreateNotification
        /// </summary>
        /// <param name="notification">Notification (NotifName, NotifDesc, EmpID, Status)</param>
        /// <returns></returns>
        public bool createNotification(Notification notification)
        {
            bool result = true;

            Notification notificationAdd = new Notification();
            notificationAdd.NotifName = notification.NotifName;
            notificationAdd.NotifDesc = notification.NotifDesc;
            notificationAdd.EmpID = notification.EmpID;
            notificationAdd.DateTime = DateTime.Now;
            notificationAdd.Status = notification.Status;

            ctx.Notification.Add(notificationAdd);
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
        /// changeStatusToRead
        /// </summary>
        /// <param name="NotifID">Notification ID</param>
        /// <returns></returns>
        public bool changeStatusToRead(string NotifID)
        {
            bool result = true;

            int notifID = Convert.ToInt32(NotifID);
            Notification notif = ctx.Notification.Where(x => x.NotifID == notifID).FirstOrDefault();
            notif.Status = "READ";

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
        /// GetNotification
        /// </summary>
        /// <param name="EmpID">Employee ID</param>
        /// <returns></returns>
        public List<Notification> getNotification(string EmpID)
        {
            int empID = Convert.ToInt32(EmpID);
            List<Notification> notifList = ctx.Notification.Where(x => x.EmpID == empID).ToList();
            return notifList;
        }

        public void sendNotification(int type, int empid, String details)
        {

            //get all Store Clerks
            List<Employee> sendToSC = ctx.Employee.Where(x => x.RoleID == "SC").ToList();

            //get all Store Supervisors
            List<Employee> sendToSS = ctx.Employee.Where(x => x.RoleID == "SS").ToList();

            //get all Store managers
            List<Employee> sendToSM = ctx.Employee.Where(x => x.RoleID == "SM").ToList();

            //get all Dept Rep
            List<Employee> sendToDR = ctx.Employee.Where(x => x.RoleID == "DR").ToList();

            //create notification
            Notification notif = new Notification();
            EmailController emailcontrol = new EmailController();
            notif.DateTime = DateTime.Now;
            notif.Status = "UNREAD";

            //Send notification by type:
            switch (type)
            {
                //Pending Requistion
                case 1:
                    {
                        notif.NotifName = "New Pending Requisition";
                        int detail = Convert.ToInt32(details);
                        notif.NotifDesc = "Requisition #" + details + " is pending for your approval.";
                        //send to Dept head of empID
                        Employee employee = ctx.Employee.Where(x => x.EmpID == empid).FirstOrDefault();
                        Employee deptHead = ctx.Employee.Where(x => x.DeptID == employee.DeptID && x.RoleID == "DH").FirstOrDefault();
                        notif.EmpID = deptHead.EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);

                        emailcontrol.SendMailToEmpHead(empid);
                        break;
                    }
                //Requisition Approved
                case 2:
                    {
                        notif.NotifName = "Requisition Approved";
                        notif.NotifDesc = "Requisition #" + details + " has been approved.";
                        // send to employee who created this requisition
                        int detail = Convert.ToInt32(details);
                        Requisition req = ctx.Requisition.Where(x => x.ReqID == detail).FirstOrDefault();
                        notif.EmpID = req.EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        emailcontrol.SendMailToEmp(emp, "APPROVED", detail);
                        break;
                    }
                //Requisition Rejected
                case 3:
                    {
                        notif.NotifName = "Requisition Rejected";
                        notif.NotifDesc = "Requisition #" + details + " has been rejected.";
                        // send to employee who created this requisition
                        int detail = Convert.ToInt32(details);
                        Requisition req = ctx.Requisition.Where(x => x.ReqID == detail).FirstOrDefault();
                        notif.EmpID = req.EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        emailcontrol.SendMailToEmp(emp, "REJECTED", detail);
                        break;
                    }
                //Processing Requisition
                case 4:
                    {
                        notif.NotifName = "Processing Requisition";
                        notif.NotifDesc = "Requisition #" + details + " is now processing.";
                        // send to employee who created this requisition
                        int detail = Convert.ToInt32(details);
                        Requisition req = ctx.Requisition.Where(x => x.ReqID == detail).FirstOrDefault();
                        notif.EmpID = req.EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        break;
                    }
                //Requisition Processed
                case 5:
                    {
                        notif.NotifName = "Requisition Processed";
                        notif.NotifDesc = "Requisition #" + details + " has been processed, ready for collection.";
                        // send to employee who created this requisition
                        int detail = Convert.ToInt32(details);
                        Requisition req = ctx.Requisition.Where(x => x.ReqID == detail).FirstOrDefault();
                        notif.EmpID = req.EmpID;
                        ctx.Notification.Add(notif);
                        int emp = Convert.ToInt32(notif.EmpID);
                        emailcontrol.SendMailToEmp(emp, "PROCESSED", detail);
                        break;
                    }
                //Requisition Disbursed
                case 6:
                    {
                        notif.NotifName = "Requisition Disbursed";
                        notif.NotifDesc = "Items in requisition #" + details + " has been disbursed.";
                        // send to employee who created this requisition
                        int detail = Convert.ToInt32(details);
                        Requisition req = ctx.Requisition.Where(x => x.ReqID == detail).FirstOrDefault();
                        notif.EmpID = req.EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        emailcontrol.SendMailToEmp(emp, "COLLECTED", detail);
                        break;
                    }
                //New Pending Adjustment Voucher
                case 7:
                    {
                        notif.NotifName = "New Pending Adjustment Voucher";
                        notif.NotifDesc = "Adjustment Voucher #" + details + " is pending for your approval.";
                        // if total amt <$250, send to supervisor, else send to store manager

                        AdjustmentVoucher adj = ctx.AdjustmentVoucher.Where(x => x.AdjID == details).FirstOrDefault();
                        if (adj.TotalAmt < 250)
                        {
                            notif.EmpID = sendToSS[0].EmpID;
                            ctx.Notification.Add(notif);

                            int emp = Convert.ToInt32(notif.EmpID);
                            string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);

                            for (int i = 1; i < sendToSS.Count; i++)
                            {
                                Notification notif2 = new Notification();
                                notif2.DateTime = DateTime.Now;
                                notif2.Status = "UNREAD";
                                notif2.EmpID = sendToSS[i].EmpID;
                                notif2.NotifName = "New Pending Adjustment Voucher";
                                notif2.NotifDesc = "Adjustment Voucher #" + details + " is pending for your approval.";
                                ctx.Notification.Add(notif2);

                                emp = Convert.ToInt32(notif.EmpID);
                                roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                                PushNotification(notif.NotifName, emp, roleID);
                            }
                        }
                        else
                        {
                            notif.EmpID = sendToSM[0].EmpID;
                            ctx.Notification.Add(notif);

                            int emp = Convert.ToInt32(notif.EmpID);
                            string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);

                            for (int i = 1; i < sendToSM.Count; i++)
                            {
                                Notification notif2 = new Notification();
                                notif2.DateTime = DateTime.Now;
                                notif2.Status = "UNREAD";
                                notif2.EmpID = sendToSM[i].EmpID;
                                notif2.NotifName = "New Pending Adjustment Voucher";
                                notif2.NotifDesc = "Adjustment Voucher #" + details + " is pending for your approval.";
                                ctx.Notification.Add(notif2);

                                emp = Convert.ToInt32(notif.EmpID);
                                roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                                PushNotification(notif.NotifName, emp, roleID);
                            }
                        }
                        break;
                    }
                //Adjustment Voucher Approved
                case 8:
                    {
                        notif.NotifName = "Adjustment Voucher Approved";
                        notif.NotifDesc = "Adjustment Voucher #" + details + " has been approved.";
                        // send to employee who created this adj voucher
                        notif.EmpID = empid;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        break;
                    }
                //Adjustment Voucher Rejected
                case 9:
                    {
                        notif.NotifName = "Adjustment Voucher Rejected";
                        notif.NotifDesc = "Adjustment Voucher #" + details + " has been rejected.";
                        // send to employee who created this adj voucher
                        notif.EmpID = empid;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        break;
                    }
                //Requisition Items Not Fulfilled
                case 10:
                    {
                        notif.NotifName = "Requisition Items Not Fulfilled";
                        notif.NotifDesc = "Requisition #" + details + " has items that are not fulfilled. Please reorder the items again.";
                        // send to employee who created this requisition
                        int detail = Convert.ToInt32(details);
                        Requisition req = ctx.Requisition.Where(x => x.ReqID == detail).FirstOrDefault();
                        notif.EmpID = req.EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);
                        break;
                    }
                //New Collection Schedule
                case 11:
                    {
                        notif.NotifName = "New Collection Schedule";
                        notif.NotifDesc = "Items are ready for collection on " + details;
                        // send to all store clerks and dept rep.
                        notif.EmpID = sendToSC[0].EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);

                        for (int i = 1; i < sendToSC.Count; i++)
                        {
                            Notification notif2 = new Notification();
                            notif2.DateTime = DateTime.Now;
                            notif2.Status = "UNREAD";
                            notif2.EmpID = sendToSC[i].EmpID;
                            notif2.NotifName = "New Collection Schedule";
                            notif2.NotifDesc = "Items are ready for collection on " + details;
                            ctx.Notification.Add(notif2);

                            emp = Convert.ToInt32(notif.EmpID);
                            roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);
                        }
                        for (int i = 0; i < sendToDR.Count; i++)
                        {
                            Notification notif3 = new Notification();
                            notif3.DateTime = DateTime.Now;
                            notif3.Status = "UNREAD";
                            notif3.EmpID = sendToDR[i].EmpID;
                            notif3.NotifName = "New Collection Schedule";
                            notif3.NotifDesc = "Items are ready for collection on " + details;
                            ctx.Notification.Add(notif3);

                            emp = Convert.ToInt32(notif.EmpID);
                            roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);
                        }
                        break;
                    }
                //Change in Department's Representative
                case 12:
                    {
                        notif.NotifName = "Change in Department's Representative";
                        notif.NotifDesc = "Department #" + details + "'s representative has been changed.";
                        // send to all store clerks
                        notif.EmpID = sendToSC[0].EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);

                        for (int i = 1; i < sendToSC.Count; i++)
                        {
                            Notification notif2 = new Notification();
                            notif2.DateTime = DateTime.Now;
                            notif2.Status = "UNREAD";
                            notif2.EmpID = sendToSC[i].EmpID;
                            notif2.NotifName = "Change in Department's Representative";
                            notif2.NotifDesc = "Department #" + details + "'s representative has been changed.";
                            ctx.Notification.Add(notif2);

                            emp = Convert.ToInt32(notif.EmpID);
                            roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);
                        }
                        break;
                    }
                //Change in Department's Collection Point
                case 13:
                    {
                        notif.NotifName = "Change in Department's Collection Point";
                        notif.NotifDesc = "Department #" + details + "'s collection point has been changed.";
                        // send to all store clerks
                        notif.EmpID = sendToSC[0].EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);

                        for (int i = 1; i < sendToSC.Count; i++)
                        {
                            Notification notif2 = new Notification();
                            notif2.DateTime = DateTime.Now;
                            notif2.Status = "UNREAD";
                            notif2.EmpID = sendToSC[i].EmpID;
                            notif2.NotifName = "Change in Department's Collection Point";
                            notif2.NotifDesc = "Department #" + details + "'s collection point has been changed.";
                            ctx.Notification.Add(notif2);

                            emp = Convert.ToInt32(notif.EmpID);
                            roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);
                        }
                        break;
                    }
                //Low Stock Inventory
                case 14:
                    {
                        notif.NotifName = "Low Stock Inventory";
                        notif.NotifDesc = "Item " + details + " is low in stock.";
                        // send to all store clerks
                        notif.EmpID = sendToSC[0].EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);

                        for (int i = 1; i < sendToSC.Count; i++)
                        {
                            Notification notif2 = new Notification();
                            notif2.DateTime = DateTime.Now;
                            notif2.Status = "UNREAD";
                            notif2.EmpID = sendToSC[i].EmpID;
                            notif2.NotifName = "Low Stock Inventory";
                            notif2.NotifDesc = "Item " + details + " is low in stock.";
                            ctx.Notification.Add(notif2);

                            emp = Convert.ToInt32(notif.EmpID);
                            roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);
                        }
                        break;
                    }
                //New Report Generated
                case 15:
                    {
                        notif.NotifName = "New Report Generated";
                        notif.NotifDesc = "Report #" + details + " has been generated.";
                        // send to all store supervisor and store manager
                        notif.EmpID = sendToSS[0].EmpID;
                        ctx.Notification.Add(notif);

                        int emp = Convert.ToInt32(notif.EmpID);
                        string roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                        PushNotification(notif.NotifName, emp, roleID);

                        for (int i = 1; i < sendToSS.Count; i++)
                        {
                            Notification notif2 = new Notification();
                            notif2.DateTime = DateTime.Now;
                            notif2.Status = "UNREAD";
                            notif2.EmpID = sendToSS[i].EmpID;
                            notif2.NotifName = "New Report Generated";
                            notif2.NotifDesc = "Report #" + details + " has been generated.";
                            ctx.Notification.Add(notif2);

                            emp = Convert.ToInt32(notif.EmpID);
                            roleID = ctx.Employee.Where(x => x.EmpID == emp).FirstOrDefault().RoleID;
                            PushNotification(notif.NotifName, emp, roleID);
                        }
                        break;
                    }
            }
            try
            {
                ctx.SaveChanges();
            }
            catch
            {

            }
        }

        public bool PushNotification(string pushMessage, int empID, string roleID)
        {
            bool isPushMessageSend = false;

            string postString = "";
            string urlpath = "https://api.parse.com/1/push";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);
            string emp = roleID + Convert.ToString(empID);
            postString = "{ \"channels\": [ \"" + emp + "\"  ], " +
                             "\"data\" : {\"alert\":\"" + pushMessage + "\"}" +
                             "}";
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = postString.Length;
                httpWebRequest.Headers.Add("X-Parse-Application-Id", "EQnJ9kuR5DKhU0UfVPr6VwN0QA0wVys00jnrv4KU");
                httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", "QcAiOpjs2ibI1f6WDtkc6cesJbOIWzf3t3igJoDN");
                httpWebRequest.Method = "POST";
                StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    JObject jObjRes = JObject.Parse(responseText);
                    if (Convert.ToString(jObjRes).IndexOf("true") != -1)
                    {
                        isPushMessageSend = true;
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }
            return isPushMessageSend;
        }
    }
}
