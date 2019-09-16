using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventGuardLists
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int GuardPositionId { get; set; }
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Pas { get; set; }
        public string Description { get; set; }

        public CEmployees Employee { get; set; }
        public EventGuardPositions GuardPosition { get; set; }
        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
