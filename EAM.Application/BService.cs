using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using EAM.Data;

namespace EAM.Application
{
    public class BService<T> : IBService<T> where T : BServiceBase, new()
    {
        private T _provider;
        public BService(IOptions<DapperOptions> options, ILogger<T> logger)
        {
            _provider = new T();
            _provider.SetDataParams(options.Value.Connection, logger);
        }
        public T Provider { get { return _provider; } }
    }
}
/*
 * no transactions are supported in code. if needed transaction it should be written in sql server sored procedure.
 */