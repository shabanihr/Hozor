using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CUsers
    {
        public CUsers()
        {
            EventCarKilometers = new HashSet<EventCarKilometers>();
            EventControlLoadings = new HashSet<EventControlLoadings>();
            EventControlLooks = new HashSet<EventControlLooks>();
            EventControlServices = new HashSet<EventControlServices>();
            EventControlWorkNighits = new HashSet<EventControlWorkNighits>();
            EventEventOthers = new HashSet<EventEventOthers>();
            EventGuardLists = new HashSet<EventGuardLists>();
            EventGuardShift = new HashSet<EventGuardShift>();
            EventGuardStatus = new HashSet<EventGuardStatus>();
            EventInspects = new HashSet<EventInspects>();
            EventPatrol = new HashSet<EventPatrol>();
            EventShiftDeliveryes = new HashSet<EventShiftDeliveryes>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }

        public ICollection<EventCarKilometers> EventCarKilometers { get; set; }
        public ICollection<EventControlLoadings> EventControlLoadings { get; set; }
        public ICollection<EventControlLooks> EventControlLooks { get; set; }
        public ICollection<EventControlServices> EventControlServices { get; set; }
        public ICollection<EventControlWorkNighits> EventControlWorkNighits { get; set; }
        public ICollection<EventEventOthers> EventEventOthers { get; set; }
        public ICollection<EventGuardLists> EventGuardLists { get; set; }
        public ICollection<EventGuardShift> EventGuardShift { get; set; }
        public ICollection<EventGuardStatus> EventGuardStatus { get; set; }
        public ICollection<EventInspects> EventInspects { get; set; }
        public ICollection<EventPatrol> EventPatrol { get; set; }
        public ICollection<EventShiftDeliveryes> EventShiftDeliveryes { get; set; }
    }
}
