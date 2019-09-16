using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcCompanys
    {
        public TcCompanys()
        {
            EventCarKilometers = new HashSet<EventCarKilometers>();
            TcCompanyTraffics = new HashSet<TcCompanyTraffics>();
        }

        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public string CarColor { get; set; }
        public string Section { get; set; }
        public bool? LightCar { get; set; }
        public bool? HeavyCar { get; set; }

        public ICollection<EventCarKilometers> EventCarKilometers { get; set; }
        public ICollection<TcCompanyTraffics> TcCompanyTraffics { get; set; }
    }
}
