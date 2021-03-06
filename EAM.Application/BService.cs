﻿using EAM.Common.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using EAM.Data;

namespace EAM.Application
{
    public class BService<T> : IBService<T> where T : IBServiceBase, new()
    {
        private T _provider;
        public BService(IOptions<DapperOptions> options, ILoggerFactory loggerFactory)
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