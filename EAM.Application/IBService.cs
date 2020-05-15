using System;
using System.Security.Cryptography;
using EAM.Data;

namespace EAM.Application
{
    public interface IBService<T> where T : BServiceBase, new()
    {
        T Provider { get; }
    }
}
