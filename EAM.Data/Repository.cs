using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Data
{
    public class Repository<T> : IRepository<T> where T : RepositoryBase, new()
    {
        private T _provider;
        public Repository(RepositoryStore store, ILogger<T> logger)
        {
            _provider = new T();
            _provider.SetOnce(store.Connection, logger);
        }
        public T Provider { get { return _provider; } }
    }
}
/*
 * no transactions are supported in code. if needed transaction it should be written in sql server sored procedure.
 */