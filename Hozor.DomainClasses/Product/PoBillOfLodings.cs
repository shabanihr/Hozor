using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class PoBillOfLodings
    {
        public int Id { get; set; }
        public string Blnumber { get; set; }
        public int BlmachinesId { get; set; }
        public DateTime DateExportation { get; set; }
        public DateTime? DateOk { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }

        public PoBlmachines Blmachines { get; set; }
    }
}
