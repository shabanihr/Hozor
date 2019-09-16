using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            _db.Entry(user).State = EntityState.Modified;
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
