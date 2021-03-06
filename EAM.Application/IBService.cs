﻿using System;
using System.Security.Cryptography;
using EAM.Data;

namespace EAM.Application
{
    public interface IBService<T> where T : IBServiceBase, new()
    {
        T provider { get; }
    }
}
