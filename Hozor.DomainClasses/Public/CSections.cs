using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hozor.DataLayer.Models
{
    public partial class CSections
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام واحد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }
    }
}
