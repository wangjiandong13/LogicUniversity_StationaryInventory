using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NotificationAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NotificationAPI.svc or NotificationAPI.svc.cs at the Solution Explorer and start debugging.
    public class NotificationAPI : INotificationAPI
    {
        public bool createNotification(Notification notification)
        {
            BusinessLogic.NotificationController BL = new BusinessLogic.NotificationController();
            return BL.createNotification(notification);
        }

        public bool changeStatusToRead(string NotifID)
        {
            BusinessLogic.NotificationController BL = new BusinessLogic.NotificationController();
            return BL.changeStatusToRead(NotifID);
        }

        public List<Notification> getNotification(string EmpID)
        {
            BusinessLogic.NotificationController BL = new BusinessLogic.NotificationController();
            return BL.getNotification(EmpID);
        }
    }
}
