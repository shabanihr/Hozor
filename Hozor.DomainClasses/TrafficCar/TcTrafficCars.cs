using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcTrafficCars
    {
        public TcTrafficCars()
        {
            TcAgencyTraffics = new HashSet<TcAgencyTraffics>();
            TcCargoTransportTraffics = new HashSet<TcCargoTransportTraffics>();
            TcCompanyTraffics = new HashSet<TcCompanyTraffics>();
            TcComrades = new HashSet<TcComrades>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }

        public ICollection<TcAgencyTraffics> TcAgencyTraffics { get; set; }
        public ICollection<TcCargoTransportTraffics> TcCargoTransportTraffics { get; set; }
        public ICollection<TcCompanyTraffics> TcCompanyTraffics { get; set; }
        public ICollection<TcComrades> TcComrades { get; set; }
    }
}
