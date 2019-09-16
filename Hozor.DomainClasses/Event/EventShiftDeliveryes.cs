using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventShiftDeliveryes
    {
        public EventShiftDeliveryes()
        {
            EventObjectDeliverys = new HashSet<EventObjectDeliverys>();
        }

        public int Id { get; set; }
        public int? ShiftId { get; set; }
        public int? UserId { get; set; }
        public string Transferee { get; set; }
        public string Delivery { get; set; }
        public TimeSpan? Time { get; set; }
        public string Description { get; set; }

        public EventShifts Shift { get; set; }
        public CUsers User { get; set; }
        public ICollection<EventObjectDeliverys> EventObjectDeliverys { get; set; }
    }
}
