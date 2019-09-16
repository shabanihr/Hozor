using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventObjects
    {
        public EventObjects()
        {
            EventObjectDeliverys = new HashSet<EventObjectDeliverys>();
        }

        public int Id { get; set; }
        public string ObjectName { get; set; }
        public int Count { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public bool? IsExist { get; set; }

        public ICollection<EventObjectDeliverys> EventObjectDeliverys { get; set; }
    }
}
