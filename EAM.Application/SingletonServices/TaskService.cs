using Dapper;
using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EAM.Data;

namespace EAM.Application.SingletonServices
{
    public class TaskService : SingletonDataClass<TaskSingleton>
    {
        public void ExecDeleteNotifications(int count)
        {
            provider.ExecDeleteNotifications(count);
        }

        public void ExecTask2(int count)
        {
            provider.ExecTask2(count);
        }

    }
}
