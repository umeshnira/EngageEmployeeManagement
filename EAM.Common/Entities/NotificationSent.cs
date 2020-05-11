using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Common.Entities
{
    public class NotificationSent
    {
        public long NotificationID { get; set; }
        public List<int> EmployeeIDs { get; set; }
    }
}
