using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hozor.DataLayer.Models
{
    public partial class CRoles
    {
        public CRoles()
        {
            this.CUsersRoles = new HashSet<CUsersRoles>();
            CRoleAccesses = new HashSet<CRoleAccesses>();
        }
        // [Key]
        public int Id { get; set; }
        public string RoleTitle { get; set; }

        [Display(Name = "نام گروه کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleName { get; set; }

        public virtual ICollection<CUsersRoles> CUsersRoles { get; set; }
        public ICollection<CRoleAccesses> CRoleAccesses { get; set; }
    }
}
