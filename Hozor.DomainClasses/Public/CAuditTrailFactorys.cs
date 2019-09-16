using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CAuditTrailFactorys
    {
        public long Id { get; set; }
        public string TableName { get; set; }
        public string UserId { get; set; }
        public string IpAddress { get; set; }
        public string Actions { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public long? TableIdValue { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
