using Hozor.DataLayer.Models;
using Hozor.ViewModels.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hozor.Servises.Repositoryes.Public;
using Microsoft.EntityFrameworkCore;

namespace Hozor.Servises.Services.Public
{
    public class AccountRep:IAccountRep
    {
        private readonly Hozor_DBContext _db;
        public AccountRep(Hozor_DBContext db)
        {
            _db = db;
        }

        public async Task<string> Login(LoginViewModel user)
        {
            var cUsers = await _db.CUsers.SingleOrDefaultAsync
            (u => u.UserName.Equals(user.UserName) && 
                  u.Password.Equals(user.Password));
            if (cUsers != null)
            {
                if (cUsers.IsActive)
                {
                    return "Success";
                }
                else
                {
                    return "NotActive";
                }
            }

            return "NotFound";


        }
    }
}
