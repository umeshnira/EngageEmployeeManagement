using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Data.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public string Test(string userName, string password)
        {
            return "hello";
        }
        public bool Validate(string userName, string password)
        {
            if (userName == "abc" && password == "abc")
            {
                return true;
            }
            return false;
        }
    }
}
