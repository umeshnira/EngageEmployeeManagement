using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using EAM.Data;

namespace EAM.Application
{
    public class BSingleton<T> : IBSingleton<T> where T : IBSingletonBase, new()
    {
        private T _provider;
        public BSingleton(IOptions<DapperOptions> options, ILoggerFactory loggerFactory)
        {
            _provider = new T();
            _provider.SetDataParams(options.Value.Connection, loggerFactory);
        }
        public T provider { get { return _provider; } }
    }
}
/*
 * no transactions are supported in code. if needed transaction it should be written in sql server sored procedure.
 */