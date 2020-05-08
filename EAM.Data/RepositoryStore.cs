using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Options;
using EAM.Common.Entities;

namespace EAM.Data
{
    public class RepositoryStore : IDisposable
    {
        public RepositoryStore(IOptions<DapperOptions> options)
        {
            Connection = options.Value.Connection;
        }
        public string Connection;
        public void Dispose()
        {
        }
    }

    public class RepositoryBase
    {
        public string Connection;
    }
}
