using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventLookPositions
    {
        public EventLookPositions()
        {
            EventControlLooks = new HashSet<EventControlLooks>();
        }

        public int Id { get; set; }
        public string LookPosition { get; set; }

        public ICollection<EventControlLooks> EventControlLooks { get; set; }
    }
}
