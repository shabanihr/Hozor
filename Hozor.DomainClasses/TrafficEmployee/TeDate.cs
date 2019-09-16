using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TeDate
    {
        public TeDate()
        {
            TeTraffic = new HashSet<TeTraffic>();
        }

        public int Id { get; set; }
        public string Date { get; set; }
        public string WeekStart { get; set; }
        public string WeekEnd { get; set; }
        public string MonthStart { get; set; }
        public string MinthEnd { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
        public string Day { get; set; }

        public ICollection<TeTraffic> TeTraffic { get; set; }
    }
}
