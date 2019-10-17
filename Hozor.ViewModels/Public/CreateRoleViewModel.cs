using Hozor.DomainClasses.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hozor.DataLayer.Models;

namespace Hozor.ViewModels.Public
{
    public class CreateRoleViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }

        public IEnumerable<CMvcControllerInfo> SelectedControllers { get; set; }
    }


    public class EditRoleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }

        public IEnumerable<CRoleAccesses> RoleAccesses { get; set; }

        public IEnumerable<CMvcControllerInfo> SelectedControllers { get; set; }

        public IEnumerable<CMvcControllerInfo> Controllers { get; set; }
    }
}
