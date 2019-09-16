using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CWorkFlows
    {
        public CWorkFlows()
        {
            EventShifts = new HashSet<EventShifts>();
            PoProductExit = new HashSet<PoProductExit>();
            TcAgencyTraffics = new HashSet<TcAgencyTraffics>();
            TcCargoTransportTraffics = new HashSet<TcCargoTransportTraffics>();
            TcCompanyTraffics = new HashSet<TcCompanyTraffics>();
            TcOtherTraffics = new HashSet<TcOtherTraffics>();
            TmEmployeeMeetings = new HashSet<TmEmployeeMeetings>();
            TmVisitorMeetings = new HashSet<TmVisitorMeetings>();
            TvVisitorTraffic = new HashSet<TvVisitorTraffic>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string UserName { get; set; }
        public string SentryLocation { get; set; }
        public string WorkFlowClass { get; set; }
        public string WriteUserName { get; set; }
        public DateTime? WriteDate { get; set; }
        public string ConfirmUserName { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string ApprovalUserName { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public ICollection<EventShifts> EventShifts { get; set; }
        public ICollection<PoProductExit> PoProductExit { get; set; }
        public ICollection<TcAgencyTraffics> TcAgencyTraffics { get; set; }
        public ICollection<TcCargoTransportTraffics> TcCargoTransportTraffics { get; set; }
        public ICollection<TcCompanyTraffics> TcCompanyTraffics { get; set; }
        public ICollection<TcOtherTraffics> TcOtherTraffics { get; set; }
        public ICollection<TmEmployeeMeetings> TmEmployeeMeetings { get; set; }
        public ICollection<TmVisitorMeetings> TmVisitorMeetings { get; set; }
        public ICollection<TvVisitorTraffic> TvVisitorTraffic { get; set; }
    }
}
