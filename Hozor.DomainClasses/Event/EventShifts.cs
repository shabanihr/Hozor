using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventShifts
    {
        public EventShifts()
        {
            EventCarKilometers = new HashSet<EventCarKilometers>();
            EventControlLoadings = new HashSet<EventControlLoadings>();
            EventControlLooks = new HashSet<EventControlLooks>();
            EventControlServices = new HashSet<EventControlServices>();
            EventControlWorkNighits = new HashSet<EventControlWorkNighits>();
            EventEventOthers = new HashSet<EventEventOthers>();
            EventGuardLists = new HashSet<EventGuardLists>();
            EventGuardStatus = new HashSet<EventGuardStatus>();
            EventInspects = new HashSet<EventInspects>();
            EventObjectDeliverys = new HashSet<EventObjectDeliverys>();
            EventPatrol = new HashSet<EventPatrol>();
            EventShiftDeliveryes = new HashSet<EventShiftDeliveryes>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ShiftNameId { get; set; }
        public int ShiftHeadId { get; set; }
        public int WorkFlowId { get; set; }

        public EventShiftHead ShiftHead { get; set; }
        public EventShiftName ShiftName { get; set; }
        public CWorkFlows WorkFlow { get; set; }
        public ICollection<EventCarKilometers> EventCarKilometers { get; set; }
        public ICollection<EventControlLoadings> EventControlLoadings { get; set; }
        public ICollection<EventControlLooks> EventControlLooks { get; set; }
        public ICollection<EventControlServices> EventControlServices { get; set; }
        public ICollection<EventControlWorkNighits> EventControlWorkNighits { get; set; }
        public ICollection<EventEventOthers> EventEventOthers { get; set; }
        public ICollection<EventGuardLists> EventGuardLists { get; set; }
        public ICollection<EventGuardStatus> EventGuardStatus { get; set; }
        public ICollection<EventInspects> EventInspects { get; set; }
        public ICollection<EventObjectDeliverys> EventObjectDeliverys { get; set; }
        public ICollection<EventPatrol> EventPatrol { get; set; }
        public ICollection<EventShiftDeliveryes> EventShiftDeliveryes { get; set; }
    }
}
