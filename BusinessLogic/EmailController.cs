using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;
using System.Net.Mail;
using Model;

namespace BusinessLogic
{
    public class EmailController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// Send Email to Dept Head when emp submit new request form
        /// </summary>
        /// <param name="empid">Employee ID</param>
        public void SendMailToEmpHead(string empid)
        {
            var name = (from n in ctx.Employee
                        where n.EmpID == Convert.ToInt32(empid)
                        select n.EmpName).First();
            string email = "logicuniversity.depthead@gmail.com";
            MailMessage mail = new MailMessage();
            mail.To.Add(email); //logicuniversity.depthead@gmail.com
            //mail.To.Add(email);
            //mail.CC.Add(CC);
            //mail.Bcc.Add(BCC);

            mail.From = new MailAddress("logicuniversity.team5@gmail.com");

            string subject = string.Format("Hi Department Head, new request has been made by {0}.", name);
            mail.Subject = subject;

            string Body = string.Format("Please process the pending requisition forms");
            mail.Body = Body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("logicuniversity.team5@gmail.com", "logicuniversity123");

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

        /// <summary>
        /// Reply from Dept Head to Emp that Approve or Reject
        /// </summary>
        /// <param name="empid">Employee ID</param>
        /// <param name="status">Approve/Reject</param>
        public void SendMailToEmp(string empid, string status)
        {
            Employee emp = new Employee();

            emp = (from n in ctx.Employee
                   where n.EmpID == Convert.ToInt32(empid)
                   select n).First();

            string email = emp.Email;
            MailMessage mail = new MailMessage();
            mail.To.Add(email); //logicuniversity.depthead@gmail.com
            //mail.To.Add(email);
            //mail.CC.Add(CC);
            //mail.Bcc.Add(BCC);

            mail.From = new MailAddress("logicuniversity.depthead@gmail.com");

            string subject = string.Format("Your requesition - {0} .", status);
            mail.Subject = subject;

            string Body = string.Format("Hi {0}, your requesition form has been {1} .", emp.EmpName, status);
            mail.Body = Body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("logicuniversity.depthead@gmail.com", "logicuniversity123");

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
    }
}
