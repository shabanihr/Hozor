using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventControlServices
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public int? Bus { get; set; }
        public int? MiniBus { get; set; }
        public int? Van { get; set; }
        public int? Car { get; set; }
        public TimeSpan? Time { get; set; }
        public string Description { get; set; }

        public CEmployees Employee { get; set; }
        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
