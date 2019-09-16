using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventControlLooks
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public int LookPositionId { get; set; }
        public int UserId { get; set; }
        public TimeSpan? Time { get; set; }
        public int? LookNumber { get; set; }
        public string Description { get; set; }

        public CEmployees Employee { get; set; }
        public EventLookPositions LookPosition { get; set; }
        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
