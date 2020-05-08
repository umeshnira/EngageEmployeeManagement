using System;
using System.Security.Cryptography;

namespace EAM.Data
{
    public interface IRepository<T> where T : RepositoryBase, new()
    {
        T Provider { get; }
    }
}
