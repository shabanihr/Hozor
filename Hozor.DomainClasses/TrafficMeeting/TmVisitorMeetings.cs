using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TmVisitorMeetings
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public int EmploeeyId { get; set; }
        public int WorkFlowId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string StartUserName { get; set; }
        public string EndUserName { get; set; }

        public CEmployees Emploeey { get; set; }
        public TvVisitors Visitor { get; set; }
        public CWorkFlows WorkFlow { get; set; }
    }
}
