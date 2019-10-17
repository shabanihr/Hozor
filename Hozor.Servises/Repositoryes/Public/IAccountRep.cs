using Hozor.DataLayer.Models;
using Hozor.ViewModels.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hozor.Servises.Repositoryes.Public
{
    public interface IAccountRep
    {
        Task<string> Login(LoginViewModel user);
        Task<CUsers> GetByUserName(string userName);
        bool UserExists(int userId);
        Task Save();
    }
}
