using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventEventOthers
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public string Titel { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }

        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
