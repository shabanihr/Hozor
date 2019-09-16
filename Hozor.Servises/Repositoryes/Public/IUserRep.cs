using Hozor.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hozor.Servises.Repositoryes.Public
{
    public interface IUserRep
    {
        List<CUsers> GetAllUsers();
        CUsers GetUserById(int userId);
        void InsertUser(CUsers user);
        void UpdateUser(CUsers user);
        void DeleteUser(CUsers user);
        void DeleteUser(int userId);
        bool UserExists(int userId);
        void Save();
    }
}
