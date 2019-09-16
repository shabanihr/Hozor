using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventInspects
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public TimeSpan? Time { get; set; }
        public string Belonging1 { get; set; }
        public string Belonging2 { get; set; }
        public string Belonging3 { get; set; }
        public string Bodily1 { get; set; }
        public string Bodily2 { get; set; }
        public string Bodily3 { get; set; }
        public string Bodily4 { get; set; }
        public string Description { get; set; }

        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
