using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class EventGuardPositions
    {
        public EventGuardPositions()
        {
            EventGuardLists = new HashSet<EventGuardLists>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventGuardLists> EventGuardLists { get; set; }
    }
}
