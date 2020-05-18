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
    public abstract class DataClass<T2> : IBServiceBase where T2 : RepositoryBase, new()
    {
        protected T2 provider { get; private set; } 
        protected ILogger logger { get; private set; }
        public void SetDataParams(string connection, ILoggerFactory loggerFactory)
        {
            provider = new T2();
            logger = loggerFactory.CreateLogger(this.GetType());
            provider.SetOnce(connection, loggerFactory.CreateLogger<T2>());
        }
    }
    public interface IBServiceBase
    {
        void SetDataParams(string connection, ILoggerFactory logger);
    }
}
