using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class PoProductExit
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WorkFlowId { get; set; }
        public DateTime Date { get; set; }
        public string ChassisNum { get; set; }
        public string PlaqueNum { get; set; }
        public string Expellant { get; set; }
        public string CardExitNum { get; set; }
        public TimeSpan? Time { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

        public PoProducts Product { get; set; }
        public CWorkFlows WorkFlow { get; set; }
    }
}
