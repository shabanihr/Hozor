using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CEmployees
    {
        public CEmployees()
        {
            EventControlLoadings = new HashSet<EventControlLoadings>();
            EventControlLooks = new HashSet<EventControlLooks>();
            EventControlServices = new HashSet<EventControlServices>();
            EventControlWorkNighits = new HashSet<EventControlWorkNighits>();
            EventGuardLists = new HashSet<EventGuardLists>();
            EventGuardShift = new HashSet<EventGuardShift>();
            EventGuardStatus = new HashSet<EventGuardStatus>();
            EventPatrol = new HashSet<EventPatrol>();
            TcCompanyTraffics = new HashSet<TcCompanyTraffics>();
            TeTraffic = new HashSet<TeTraffic>();
            TmEmployeeMeetingsHost = new HashSet<TmEmployeeMeetings>();
            TmEmployeeMeetingsMeeter = new HashSet<TmEmployeeMeetings>();
            TmVisitorMeetings = new HashSet<TmVisitorMeetings>();
            TvVisitorTraffic = new HashSet<TvVisitorTraffic>();
        }

        public int Id { get; set; }
        public int PersonalId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Job { get; set; }
        public string Category { get; set; }
        public byte[] Image { get; set; }
        public bool? IsActive { get; set; }
        public int? ImageNumber { get; set; }
        public string FerstName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Section { get; set; }
        public string ImageName { get; set; }

        public ICollection<EventControlLoadings> EventControlLoadings { get; set; }
        public ICollection<EventControlLooks> EventControlLooks { get; set; }
        public ICollection<EventControlServices> EventControlServices { get; set; }
        public ICollection<EventControlWorkNighits> EventControlWorkNighits { get; set; }
        public ICollection<EventGuardLists> EventGuardLists { get; set; }
        public ICollection<EventGuardShift> EventGuardShift { get; set; }
        public ICollection<EventGuardStatus> EventGuardStatus { get; set; }
        public ICollection<EventPatrol> EventPatrol { get; set; }
        public ICollection<TcCompanyTraffics> TcCompanyTraffics { get; set; }
        public ICollection<TeTraffic> TeTraffic { get; set; }
        public ICollection<TmEmployeeMeetings> TmEmployeeMeetingsHost { get; set; }
        public ICollection<TmEmployeeMeetings> TmEmployeeMeetingsMeeter { get; set; }
        public ICollection<TmVisitorMeetings> TmVisitorMeetings { get; set; }
        public ICollection<TvVisitorTraffic> TvVisitorTraffic { get; set; }
    }
}
