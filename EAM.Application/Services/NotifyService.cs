using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using EAM.Common;
using EAM.Common.Entities;
using EAM.Common.Constants;
using EAM.Data.Repositories;

namespace EAM.Application.Services
{
    public class NotifyService : DataClass<NotifyRepository>
    {
        public long CreateNotification(Notification notification, int userId)
        {
            return provider.CreateNotification(notification, userId);
        }

        public Notification GetOne(long id, int userId)
        {
            return provider.GetOne(id, userId);
        }

        public bool DeleteOne(long id, int userId)
        {
            return provider.DeleteOne(id, userId);
        }

        public List<NotificationList> GetAdminList(bool isDeleted)
        {
            return provider.GetAdminList(isDeleted);
        }
        public bool AssignToUsers(NotificationSent list)
        {
            return provider.AssignToUsers(list);
        }
        public List<Notification> UserNotificationList(int userId)
        {
            return provider.UserNotificationList(userId);
        }

        public bool ActionTaken(long notificationID, int userId)
        {
            return ActionTaken(notificationID, userId);
        }
    }
}
