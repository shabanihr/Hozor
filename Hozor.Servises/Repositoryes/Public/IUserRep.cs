using Hozor.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Hozor.ViewModels.Public;
using System.Threading.Tasks;

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
        List<CUsers> FilterUser(string userName, bool isActive, string startDate, string endDate);
        bool UserExists(int userId);
        Task Save();
    }
}
