using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
        public List<Notification> getNotification (string EmpID)
        {
            int empID = Convert.ToInt32(EmpID);
            List<Notification> notifList = ctx.Notification.Where(x => x.EmpID == empID).ToList();
            return notifList;
        }

    }
}
