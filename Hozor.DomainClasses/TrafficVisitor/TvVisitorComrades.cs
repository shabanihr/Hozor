using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TvVisitorComrades
    {
        public int Id { get; set; }
        public int VisitorTrafficId { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }

        public TvVisitorTraffic VisitorTraffic { get; set; }
    }
}
