using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CRoleAccesses
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int RoleId { get; set; }

        public CRoles Role { get; set; }
    }
}
