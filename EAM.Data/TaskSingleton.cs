﻿using Dapper;
using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EAM.Data
{
    public class TaskSingleton 
    {
        private readonly string Connection;
        private readonly ILogger Logger;
        public TaskSingleton(IOptions<DapperOptions> options, ILogger<TaskSingleton> logger)
        {
            Connection = options.Value.Connection;
            Logger = logger;
        }
        public void ExecDeleteNotifications(bool stop, int count)
        {
            if (!stop)
            {
                using (var conn = new SqlConnection(this.Connection))
                {
                    if (!stop)
                    {
                        var affected1 = conn.Execute("DELETE FROM NotificationSent WHERE NotificationID IN "+
                            $" (SELECT TOP ({count}) a.NotificationID FROM Notification a WHERE a.Deleted = 1)");
                        Logger.LogInformation($"Affected Deleted NotificationSent(S) {affected1}");
                    }
                    if (!stop)
                    {
                        var affected2 = conn.Execute($"DELETE TOP ({count}) FROM Notification WHERE NotificationID IN " +
                            " (SELECT a.NotificationID FROM Notification a LEFT JOIN NotificationSent b ON " +
                            " a.NotificationID = b.NotificationID AND b.NotificationId IS NULL);");
                        Logger.LogInformation($"Affected Deleted Notification(S) {affected2}");
                    }
                }
            }
        }
    }
}
