using System;
using System.Collections.Generic;
using System.Text;

namespace EAM.Common.Entities
{
    public class JWTOptions
    {
        public string Secret { get; set; }
        public int MinutesToExpire { get; set; }
    }
}
