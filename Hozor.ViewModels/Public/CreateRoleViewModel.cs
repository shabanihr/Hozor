using Hozor.DomainClasses.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hozor.DataLayer.Models;

namespace Hozor.ViewModels.Public
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name="نام گروه كاربري")]
        public string Name { get; set; }

        public IEnumerable<CMvcControllerInfo> SelectedControllers { get; set; }
    }


    public class EditRoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "نام گروه كاربري")]
        public string Name { get; set; }

        public IEnumerable<CRoleAccesses> RoleAccesses { get; set; }

        public IEnumerable<CMvcControllerInfo> SelectedControllers { get; set; }

        public IEnumerable<CMvcControllerInfo> Controllers { get; set; }
    }

    public class UserRoleViewModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }

    public class EditUserRoleViewModel
    {
        [Required]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public IEnumerable<string> SelectedRoles { get; set; }

        public IEnumerable<CRoles> Roles { get; set; }
    }
}
