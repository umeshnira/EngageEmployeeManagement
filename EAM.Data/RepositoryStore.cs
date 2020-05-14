using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Options;
using EAM.Common.Entities;
using Microsoft.Extensions.Logging;

namespace EAM.Data
{
    public class RepositoryStore : IDisposable
    {
        public RepositoryStore(IOptions<DapperOptions> options)
        {
            Connection = options.Value.Connection;
        }
        public readonly string Connection;
        public void Dispose()
        {
        }
    }

    public class RepositoryBase
    {
        public string Connection { get; private set; }
        public ILogger Logger  { get; private set; }

        public void SetOnce(string connection, ILogger logger)
        {
            if (this.Connection == null) { this.Connection = connection; }
            else { logger.LogError("Trying to reset connection."); }
            if (this.Logger == null) { this.Logger = logger; }
            else { logger.LogError("Trying to reset logger."); }
        }
    }
}
