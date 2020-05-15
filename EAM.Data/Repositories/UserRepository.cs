using Dapper;
using EAM.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EAM.Data.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public string Test(string userName, string password)
        {
            return "hello";
        }
        public LoginInfo Validate(string userName, string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            using (var conn = new SqlConnection(this.Connection))
            {
                var eid = conn.ExecuteScalar<int?>("SELECT EmployeeID FROM Login a INNER JOIN Employee b " +
                    " ON a.EmployeeId = b.EmployeeId" +
                    " WHERE a.Password = @pass AND b.EmailID = @email", new { email = userName, pass = passwordBytes });
                if (0 < (eid ?? 0))
                {
                    var roles = conn.Query<string>("SELECT RoleID FROM EmployeeRole WHERE EmployeeID = @eid", new { eid = (eid ?? 0) }).AsList();
                    return new LoginInfo() { EmployeeID = (eid.Value), Roles = roles };
                }
            }
            return null;
        }
    }
}
