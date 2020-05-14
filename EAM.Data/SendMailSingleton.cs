using Dapper;
using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EAM.Data
{
    public class SendMailSingleton 
    {
        private readonly string Connection;
        private readonly ILogger Logger;

        public volatile bool stop = false;

        public SendMailSingleton(IOptions<DapperOptions> options, ILogger<SendMailSingleton> logger)
        {
            Connection = options.Value.Connection;
            Logger = logger;
        }

        public void ExecSendMail(int count)
        {
            if (!stop)
            {
                using (var conn = new SqlConnection(this.Connection))
                {
                    if (!stop)
                    {
                       
                        Logger.LogInformation($"SendMail 0");
                    }
                    if (!stop)
                    {
                        
                        Logger.LogInformation($"SendMail 1");
                    }
                }
            }
        }
    }
}
