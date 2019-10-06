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
        Task <List<CUsers>> GetAllUsers();
        Task <CUsers> GetUserById(int userId);
        Task InsertUser(CUsers user);
        Task UpdateUser(CUsers user);
        Task DeleteUser(int userId);
        Task <List<CUsers>> FilterUser(string userName, bool isActive, string startDate, string endDate);
        Task ChangePassword(ChangePasswordViewModel user);
        bool UserExists(int userId);
        Task Save();
    }
}
