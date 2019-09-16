using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcCargoTransports
    {
        public TcCargoTransports()
        {
            TcCargoTransportTraffics = new HashSet<TcCargoTransportTraffics>();
        }

        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverFamily { get; set; }
        public string DriverNationalId { get; set; }

        public ICollection<TcCargoTransportTraffics> TcCargoTransportTraffics { get; set; }
    }
}
