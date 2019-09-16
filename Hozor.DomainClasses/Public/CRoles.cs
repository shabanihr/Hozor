using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CRoles
    {
        public CRoles()
        {
            CRoleAccesses = new HashSet<CRoleAccesses>();
        }

        public int Id { get; set; }
        public string RoleTitle { get; set; }
        public string RoleName { get; set; }

        public ICollection<CRoleAccesses> CRoleAccesses { get; set; }
    }
}
