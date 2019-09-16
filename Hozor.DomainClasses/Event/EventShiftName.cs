using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventShiftName
    {
        public EventShiftName()
        {
            EventGuardShift = new HashSet<EventGuardShift>();
            EventShifts = new HashSet<EventShifts>();
        }

        public int Id { get; set; }
        public string ShiftName { get; set; }

        public ICollection<EventGuardShift> EventGuardShift { get; set; }
        public ICollection<EventShifts> EventShifts { get; set; }
    }
}
