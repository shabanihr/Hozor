using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.ViewModels.Public;

namespace Hozor.Servises.Repositoryes.Public
{
    public interface ISection
    {
        Task<List<CSections>> GetAllSections();
        Task<CSections> GetSectionById(int userId);
        Task<CUsers> GetByUserName(string userName);
        Task InsertUser(CUsers user);
        Task<string> AnyUser‍Insert(CUsers user);
        Task UpdateUser(CUsers user);
        Task<string> AnyUser‍Update(CUsers user);
        Task DeleteUser(int userId);
        Task<List<CUsers>> FilterUser(string userName, bool isActive, string startDate, string endDate);
        Task ChangePassword(ChangePasswordViewModel user);
        Task ChangePasswordUser(CUsers user);
        bool UserExists(int userId);
        Task Save();
    }
}
