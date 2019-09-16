﻿using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventPatrol
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string PatrolPosition { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }

        public CEmployees Employee { get; set; }
        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
