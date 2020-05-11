using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using EAM.Common;
using EAM.Common.Entities;
using EAM.Common.Constants;

namespace EAM.Data.Repositories
{
    public class NotifyRepository : RepositoryBase
    {
        public long CreateNotification(Notification notification, int userId)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                var id = conn.ExecuteScalar<long>(
                    @"INSERT INTO Notification(Title, Description, CreatedBy, CreatedDate)
VALUES (@Title, @Desc, @UserId, @Date); SELECT SCOPE_IDENTITY();",
                    new
                    {
                        Title = notification.Title,
                        Desc = notification.Description,
                        UserId = userId,
                        Date = DateTime.UtcNow
                    });
                return id;
            }
        }

        public Notification GetOne(long id, int userId)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                var notification = conn.QueryFirst<Notification>(@"
SELECT NotificationID, Title, Description FROM Notification WHERE NotificationID = @nid;",
                new { nid = id });

                return notification;
            }
        }

        public bool DeleteOne(long id, int userId)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                var result = conn.ExecuteScalar<int>(@"DELETE FROM Notification WHERE NotificationID = @nid; SELECT 1;",
                    new { nid = id });
                return (result == 1);
            }
        }

        public List<NotificationList> GetAdminList(bool isDeleted)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                var notifications = conn.Query<NotificationList>(@"
SELECT a.NotificationID, a.Title, a.Description, a.CreatedDate, 
ISNULL(b.FirstName + ' ', '') + ISNULL(b.LastName, '') as CreatedUserName 
FROM Notification a INNER JOIN Employee b ON a.CreatedBy = b.EmployeeID WHERE Deleted = @isDel;",
                new { isDel = isDeleted }).AsList();

                return notifications;
            }

        }
        public bool AssignToUsers(NotificationSent list)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                foreach (var oneuser in list.EmployeeIDs)
                {
                    conn.Execute(@"INSERT INTO NotificationSent (NotificationID, SentTo, Status)
SELECT @nid, @sentto, @status WHERE NOT EXISTS 
(SELECT NotificationID FROM NotificationSent WHERE NotificationID = nid2 AND SentTo = @sento2);",
                    new
                    {
                        nid = list.NotificationID,
                        sentto = oneuser,
                        status = (int)NotificationStatus.Sent,
                        nid2 = list.NotificationID,
                        @sentto2 = oneuser
                    });
                }
                return true;
            }
        }
        public List<Notification> UserNotificationList(int userId)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                conn.Execute(@"UPDATE NotificationSent  
SET Status = @status, ViewDate = @viewDate WHERE SentTo = @sentto AND Status = @status1;",
                new
                {
                    status = (int)NotificationStatus.Viewed,
                    viewDate = DateTime.UtcNow,
                    sentto = userId,
                    status1 = (int)NotificationStatus.Sent
                });
                var notifications = conn.Query<Notification>(@"SELECT a.NotificationID, a.Title, a.Description FROM 
Notification a INNER JOIN NotificationSent b ON a.NotificationID = b.NotificationID WHERE b.SentTo = @sentto AND b.Status = @status1;",
                new
                {
                    sentto = userId,
                    status1 = (int)NotificationStatus.Viewed
                }).AsList();
                return notifications;
            }

        }

        public bool ActionTaken(long notificationID, int userId)
        {
            using (var conn = new SqlConnection(this.Connection))
            {
                conn.Execute(@"UPDATE NotificationSent  
SET Status = @status, ViewDate = @viewDate WHERE SentTo = @sentto AND NotificationID = @nid;",
                new
                {
                    sentto = userId,
                    nid = notificationID
                });
                return true;
            }
        }
    }
}
