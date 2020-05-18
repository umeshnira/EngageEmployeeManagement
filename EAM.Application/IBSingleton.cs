using System;
using System.Security.Cryptography;
using EAM.Data;

namespace EAM.Application
{
    public interface IBSingleton<T> where T : IBSingletonBase, new()
    {
        T provider { get; }
    }
}
