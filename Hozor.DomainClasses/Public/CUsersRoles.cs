using System;
using System.Collections.Generic;

namespace Hozor.DataLayer.Models
{
    public partial class CUsersRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public CRoles Role { get; set; }
        public CUsers User { get; set; }
    }
}
