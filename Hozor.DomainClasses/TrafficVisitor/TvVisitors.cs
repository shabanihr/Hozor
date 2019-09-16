using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class TvVisitors
    {
        public TvVisitors()
        {
            TmVisitorMeetings = new HashSet<TmVisitorMeetings>();
            TvVisitorTraffic = new HashSet<TvVisitorTraffic>();
        }

        public int Id { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Company { get; set; }
        public string Car { get; set; }
        public string CarNumber { get; set; }
        public string Image { get; set; }

        public ICollection<TmVisitorMeetings> TmVisitorMeetings { get; set; }
        public ICollection<TvVisitorTraffic> TvVisitorTraffic { get; set; }
    }
}
