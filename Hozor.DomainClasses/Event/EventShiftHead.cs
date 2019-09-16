using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventShiftHead
    {
        public EventShiftHead()
        {
            EventShifts = new HashSet<EventShifts>();
        }

        public int Id { get; set; }
        public string ShiftHed { get; set; }
        public bool? IsActive { get; set; }
        public int? SortNumber { get; set; }

        public ICollection<EventShifts> EventShifts { get; set; }
    }
}
