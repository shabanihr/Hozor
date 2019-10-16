using System;
using System.Collections.Generic;

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
        public string RoleName { get; set; }

        public virtual ICollection<CUsersRoles> CUsersRoles { get; set; }
        public ICollection<CRoleAccesses> CRoleAccesses { get; set; }
    }
}
