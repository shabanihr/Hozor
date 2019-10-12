using Hozor.DataLayer.Models;
using Hozor.ViewModels.Public;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task ChangePasswordUser(CUsers user)
        {
            var dbModel = await GetByUserName(user.UserName);
            dbModel.Password = user.Password;
            _db.Entry(dbModel).State = EntityState.Modified;
        }

        public async Task<CUsers> GetByUserName(string userName)
        {
            return await _db.CUsers.Where(u=>u.UserName== userName).SingleAsync();
        }


        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public bool UserExists(int userId)
        {
            return _db.CUsers.Any(u => u.Id == userId);
        }
    }
}
