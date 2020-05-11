using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Common.Entities
{
    public class Notification
    {
        public long NotificationID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class NotificationList
    {
        public long NotificationID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class SuccessObj<T>
    {
        public T result { get; set; }
        public bool success { get; set; }
    }

    public class PostObj<T>
    {
        public T id { get; set; }
    }
}
