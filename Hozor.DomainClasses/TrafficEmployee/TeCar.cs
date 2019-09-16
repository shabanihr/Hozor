using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TeCar
    {
        public TeCar()
        {
            TeTraffic = new HashSet<TeTraffic>();
        }

        public int Id { get; set; }
        public string CarClass { get; set; }
        public string CarNumber { get; set; }

        public ICollection<TeTraffic> TeTraffic { get; set; }
    }
}
