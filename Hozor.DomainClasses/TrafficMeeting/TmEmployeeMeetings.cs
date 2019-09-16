using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TmEmployeeMeetings
    {
        public int Id { get; set; }
        public int MeeterId { get; set; }
        public int HostId { get; set; }
        public int WorkFlowId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string StartUserName { get; set; }
        public string EndUserName { get; set; }

        public CEmployees Host { get; set; }
        public CEmployees Meeter { get; set; }
        public CWorkFlows WorkFlow { get; set; }
    }
}
