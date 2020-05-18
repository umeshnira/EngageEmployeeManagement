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
    public abstract class SingletonDataClass<T2> : IBSingletonBase where T2 : DataSingletonBase, new()
    {
        protected T2 provider { get; private set; } 
        protected ILogger logger { get; private set; }
        public void SetDataParams(string connection, ILoggerFactory loggerFactory)
        {
            provider = new T2();
            logger = loggerFactory.CreateLogger(this.GetType());
            provider.SetOnce(connection, loggerFactory.CreateLogger<T2>());
        }

        public void TryStop()
        {
            provider.stop = true;
        }
    }
    public interface IBSingletonBase
    {
        void SetDataParams(string connection, ILoggerFactory loggerFactory);
    }
}
