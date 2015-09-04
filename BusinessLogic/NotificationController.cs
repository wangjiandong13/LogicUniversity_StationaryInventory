using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    class NotificationController
    {
        StationeryInventory_Team_05Entities ctx = new StationeryInventory_Team_05Entities();

        /// <summary>
        /// CreateNotification
        /// </summary>
        /// <param name="notification">Notification (NotifName, NotifDesc, EmpID, Status)</param>
        /// <returns></returns>
        public bool createNotification(Notification notification)
        {
            bool result = false;

            Notification notificationAdd = new Notification();
            notificationAdd.NotifName = notification.NotifName;
            notificationAdd.NotifDesc = notification.NotifDesc;
            notificationAdd.EmpID = notification.EmpID;
            notificationAdd.DateTime = DateTime.Now;
            notificationAdd.Status = notification.Status;

            ctx.Notification.Add(notificationAdd);
            int count = ctx.SaveChanges();

            if(count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// changeStatusToRead
        /// </summary>
        /// <param name="NotifID">Notification ID</param>
        /// <returns></returns>
        public bool changeStatusToRead(int NotifID)
        {
            bool result = true;

            Notification notif = ctx.Notification.Where(x => x.NotifID == NotifID).FirstOrDefault();
            notif.Status = "READ";

            int count = ctx.SaveChanges();

            if (count > 0)
                result = true;

            return result;
        }

        /// <summary>
        /// GetNotification
        /// </summary>
        /// <param name="EmpID">Employee ID</param>
        /// <returns></returns>
        public List<Notification> getNotification (int EmpID)
        {
            List<Notification> notifList = ctx.Notification.Where(x => x.EmpID == EmpID).ToList();
            return notifList;
        }

    }
}
