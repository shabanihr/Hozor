using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class PoBlmachines
    {
        public PoBlmachines()
        {
            PoBillOfLodings = new HashSet<PoBillOfLodings>();
        }

        public int Id { get; set; }
        public string MachineName { get; set; }
        public string DriverName { get; set; }
        public string MachineNumber { get; set; }

        public ICollection<PoBillOfLodings> PoBillOfLodings { get; set; }
    }
}
