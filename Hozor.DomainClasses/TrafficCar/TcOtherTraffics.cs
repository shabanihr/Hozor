using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcOtherTraffics
    {
        public int Id { get; set; }
        public int OtherId { get; set; }
        public int WorkFlowId { get; set; }
        public string ArrivalDriverName { get; set; }
        public string ArrivalDriverNationalId { get; set; }
        public string TrafficCause { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string ArrivalDoor { get; set; }
        public string ArrivalUserName { get; set; }
        public string ExitDriverName { get; set; }
        public string ExitDriverNationalId { get; set; }
        public TimeSpan? ExitTime { get; set; }
        public DateTime? ExitDate { get; set; }
        public string ExitDoor { get; set; }
        public string ExitUserName { get; set; }
        public string Discription { get; set; }

        public TcOthers Other { get; set; }
        public CWorkFlows WorkFlow { get; set; }
    }
}
