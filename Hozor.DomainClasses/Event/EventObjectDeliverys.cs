using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventObjectDeliverys
    {
        public int Id { get; set; }
        public int ShiftDeliveryId { get; set; }
        public int ObjectId { get; set; }
        public int ShiftId { get; set; }
        public bool? IsDelivery { get; set; }
        public bool? IsHealthful { get; set; }
        public bool? IsNotHealthful { get; set; }
        public string Description { get; set; }

        public EventObjects Object { get; set; }
        public EventShifts Shift { get; set; }
        public EventShiftDeliveryes ShiftDelivery { get; set; }
    }
}
