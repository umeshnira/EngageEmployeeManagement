using Dapper;
using EAM.Application;
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
    public class SendMailService : SingletonDataClass<SendMailSingleton> 
    {
        public void ExecSendMail(int count)
        {
            provider.ExecSendMail(count);
        }
    }
}
