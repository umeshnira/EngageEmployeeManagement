using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Options;
using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using EAM.Data;

namespace EAM.Application
{
    public abstract class DataClass<T2> : BServiceBase where T2 : RepositoryBase
    {
        protected T2 Provider { get; set; } 
        public void SetDataParams(string connection, ILogger logger)
        {
            Provider.SetOnce(connection, logger);
        }
    }
    public interface BServiceBase
    {
        void SetDataParams(string connection, ILogger logger);
    }
}
