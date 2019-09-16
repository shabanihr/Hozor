using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class PoProducts
    {
        public PoProducts()
        {
            PoProductExit = new HashSet<PoProductExit>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int OrderBy { get; set; }

        public ICollection<PoProductExit> PoProductExit { get; set; }
    }
}
