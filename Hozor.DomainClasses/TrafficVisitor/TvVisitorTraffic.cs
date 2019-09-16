using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TvVisitorTraffic
    {
        public TvVisitorTraffic()
        {
            TvVisitorComrades = new HashSet<TvVisitorComrades>();
        }

        public int Id { get; set; }
        public int VisitorId { get; set; }
        public int EmployeeId { get; set; }
        public int WorkFlowId { get; set; }
        public DateTime? ExitDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ExitTime { get; set; }
        public string ArrivalDoor { get; set; }
        public string ExitDoor { get; set; }
        public string ArrivalUserName { get; set; }
        public string ExitUserName { get; set; }
        public string Description { get; set; }

        public CEmployees Employee { get; set; }
        public TvVisitors Visitor { get; set; }
        public CWorkFlows WorkFlow { get; set; }
        public ICollection<TvVisitorComrades> TvVisitorComrades { get; set; }
    }
}
