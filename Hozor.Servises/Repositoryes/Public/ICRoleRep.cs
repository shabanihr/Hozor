using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;

namespace Hozor.Servises.Repositoryes.Public
{
    public interface ICRoleRep
    {
        Task<List<CRoles>> GetAllRoles();
        Task<CRoles> GetRoleById(int id);
        Task<List<CRoleAccesses>> GetRoleAccessByRoleId(int roleId);
        Task<int> GetRoleSelectId(string roleName);
        Task<int> GetTopRoleId();
        Task<bool> IsRoleByName(string name);
        Task<bool> IsRoleById(string name,int id);
        Task<bool> IsUserRole(int roleId);
        Task InsertRole(CRoles role);
        Task InsertRoleAccess(CRoleAccesses roleAccess);
        Task UpdateRole(CRoles role);
        Task DeleteRole(CRoles role);
        Task DeleteRoleAccess(int roleId);
        bool RoleExists(int roleId);
        Task Save();
    }
}
