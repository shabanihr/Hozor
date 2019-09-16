using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventCarKilometers
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int CarCompanyId { get; set; }
        public int? UserId { get; set; }
        public int? StartKilometer { get; set; }
        public int? EndKilometer { get; set; }
        public double? FunctionKilometer { get; set; }
        public string Description { get; set; }

        public TcCompanys CarCompany { get; set; }
        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
    }
}
