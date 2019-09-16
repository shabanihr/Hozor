using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventGuardShift
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftNameId { get; set; }
        public int UserId { get; set; }
        public string Job { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }

        public CEmployees Employee { get; set; }
        public EventShiftName ShiftName { get; set; }
        public CUsers User { get; set; }
    }
}
