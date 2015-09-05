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

namespace BusinessLogic
{
    public class EmailController
    {
        public void SendMail(string email)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email);

            mail.From = new MailAddress("logicuniversity.team5@gmail.com");
            mail.Subject = "Welcome To Logic University Store";
            //string Body = string.Format("Dear {0}, welcome to Golden Circle! Your membership number is {1}.", fname + " " + familyname, id);
            string Body = string.Format("Hi Customer.");
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
    }
}
