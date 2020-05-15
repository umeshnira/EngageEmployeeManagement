using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Common.Entities
{
    public class LoginInfo
    { 
        public int EmployeeID { get; set; }
        public List<string> Roles { get; set; }
    }
}
