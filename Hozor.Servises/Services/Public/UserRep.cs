using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  Hozor.ViewModels.Public;

namespace Hozor.Servises.Services.Public
{
    public class UserRep : IUserRep
    {
        private Hozor_DBContext _db;
        public UserRep(Hozor_DBContext db)
        {
            _db = db;
        }


        public List<CUsers> GetAllUsers()
        {
            return _db.CUsers.ToList();
        }

        public CUsers GetUserById(int userId)
        {
            return _db.CUsers.Find(userId);
        }

        public void InsertUser(CUsers user)
        {
           _db.CUsers.Add(user);
        }

        public void UpdateUser(CUsers user)
        {
            var dbModel = _db.CUsers.Find(user.Id);
            dbModel.UserName = user.UserName;
            dbModel.IsActive = user.IsActive;
            _db.Entry(dbModel).State = EntityState.Modified;
        }
        public void DeleteUser(CUsers user)
        {
            _db.Entry(user).State = EntityState.Deleted;
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            DeleteUser(user);
        }


        public List<CUsers> FilterUser(string userName, bool isActive, string startDate, string endDate)
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

            return list.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public bool UserExists(int userId)
        {
            return _db.CUsers.Any(u=>u.Id==userId);
        }

        
    }
}
