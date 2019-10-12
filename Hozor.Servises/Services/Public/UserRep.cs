using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Hozor.ViewModels.Public;
using System.Threading.Tasks;

namespace Hozor.Servises.Services.Public
{
    public class UserRep : IUserRep
    {
        private readonly Hozor_DBContext _db;
        public UserRep(Hozor_DBContext db)
        {
            _db = db;
        }


        public async Task <List<CUsers>> GetAllUsers()
        {
            return await _db.CUsers.OrderByDescending(u=>u.Id).ToListAsync();
        }

        public async Task <CUsers> GetUserById(int userId)
        {
            return await _db.CUsers.FindAsync(userId);
        }

        public async Task InsertUser(CUsers user)
        {
            await _db.CUsers.AddAsync(user);
        }

        public async Task<string> AnyUser‍Insert(CUsers user)
        {
            
            return Convert.ToString(await _db.CUsers.AnyAsync(u => u.UserName == user.UserName));
        }

        public async Task UpdateUser(CUsers user)
        {
            var dbModel =await GetUserById(user.Id);
            dbModel.UserName = user.UserName;
            dbModel.IsActive = user.IsActive;
            _db.Entry(dbModel).State = EntityState.Modified;
        }

        public async Task<string> AnyUser‍Update(CUsers user)
        {
            return Convert.ToString(await _db.CUsers.AnyAsync(u => u.UserName == user.UserName && u.Id!=user.Id));
        }

        public async Task DeleteUser(int userId)
        {
            var user = await GetUserById(userId);
            _db.Entry(user).State = EntityState.Deleted;
        }


        public async Task <List<CUsers>> FilterUser(string userName, bool isActive, string startDate, string endDate)
        {
            IQueryable<CUsers> list = _db.CUsers;

            list = list.Where(u => u.IsActive == isActive);

            if (userName != null)
            {
                list = list.Where(u => u.UserName.Contains(userName));
            }

            if (startDate != null)
            {
                DateTime date = Convert.ToDateTime(startDate);
                list = list.Where(u => u.RegisterDate >= date);
            }

            if (endDate != null)
            {
                DateTime date = Convert.ToDateTime(endDate);
                list = list.Where(u => u.RegisterDate <= date);
            }

            return await list.ToListAsync();
        }

        public async Task ChangePassword(ChangePasswordViewModel user)
        {
            var dbModel = await GetUserById(user.Id);
            dbModel.Password = user.Password;
            _db.Entry(dbModel).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public bool UserExists(int userId)
        {
            return _db.CUsers.Any(u=>u.Id==userId);
        }

        
    }
}
