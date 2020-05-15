using Dapper;
using EAM.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EAM.Data.Repositories;

namespace EAM.Application.Services
{
    public class UserService : DataClass<UserRepository>
    {
        public string Test(string userName, string password)
        {
            return Provider.Test(userName, password);
        }
        public LoginInfo Validate(string userName, string password)
        {
            return Provider.Validate(userName, password);
        }
    }
}
