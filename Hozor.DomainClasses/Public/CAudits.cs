using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CAudits
    {
        public long Id { get; set; }
        public string AreaAccessed { get; set; }
        public string UserName { get; set; }
        public string Ipaddress { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
