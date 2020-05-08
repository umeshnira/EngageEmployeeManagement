﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Data
{
    public class Repository<T> : IRepository<T> where T : RepositoryBase, new()
    {
        private T _provider;
        public Repository(RepositoryStore store)
        {
            _provider = new T();
            _provider.Connection = store.Connection;
        }
        public T Provider { get { return _provider; } }
    }
}
/*
 * no transactions are supported in code. if needed transaction it should be written in sql server sored procedure.
 */