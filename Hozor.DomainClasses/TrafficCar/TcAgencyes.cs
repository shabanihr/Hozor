using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcAgencyes
    {
        public TcAgencyes()
        {
            TcAgencyTraffics = new HashSet<TcAgencyTraffics>();
        }

        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public string CarColor { get; set; }
        public string DriverName { get; set; }
        public string DriverFamily { get; set; }
        public string DriverNationalId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<TcAgencyTraffics> TcAgencyTraffics { get; set; }
    }
}
