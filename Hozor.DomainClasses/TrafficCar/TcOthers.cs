using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TcOthers
    {
        public TcOthers()
        {
            TcOtherTraffics = new HashSet<TcOtherTraffics>();
        }

        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public string Company { get; set; }

        public ICollection<TcOtherTraffics> TcOtherTraffics { get; set; }
    }
}
