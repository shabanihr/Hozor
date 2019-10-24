using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Microsoft.EntityFrameworkCore;

namespace Hozor.Servises.Services.Public
{
    public class RoleRep:ICRoleRep
    {
        private readonly Hozor_DBContext _db;

        public RoleRep(Hozor_DBContext db)
        {
            _db = db;
        }
        public async Task<List<CRoles>> GetAllRoles()
        {
            return await _db.CRoles.OrderByDescending(r => r.Id).ToListAsync();
        }

        public async Task<CRoles> GetRoleById(int id)
        {
            return await _db.CRoles.FindAsync(id);
        }

        public async Task<List<CRoleAccesses>> GetRoleAccessByRoleId(int rolId)
        {
            return await _db.CRoleAccesses.Where(r=>r.RoleId==rolId).ToListAsync();
        }

        public async Task<int> GetRoleSelectId(string roleName)
        {
            return await _db.CRoles.Where(r => r.RoleName == roleName).Select(r => r.Id).SingleAsync();
        }

        public async Task<int> GetTopRoleId()
        {
            return await _db.CRoles.Select(r => r.Id).LastOrDefaultAsync();
        }

        public async Task<bool> IsRoleByName(string name)
        {

            return await _db.CRoles.AnyAsync(r=>r.RoleName==name);
        }

        public async Task<bool> IsRoleById(string name,int id)
        {
            return await _db.CRoles.AnyAsync(r=>r.RoleName==name && r.Id != id);
        }

        public async Task<bool> IsUserRole(int roleId)
        {
            return await _db.CUsersRoles.AnyAsync(r => r.RoleId == roleId);
        }
        public async Task InsertRole(CRoles role)
        {
            await _db.CRoles.AddAsync(role);
        }

        public async Task InsertRoleAccess(CRoleAccesses roleAccess)
        {
            await _db.AddAsync(roleAccess);
        }

        public async Task UpdateRole(CRoles role)
        {
            _db.Entry(role).State = EntityState.Modified;
        }

        public async Task DeleteRole(CRoles role)
        {
            _db.Entry(role).State = EntityState.Deleted;
        }

        public async Task DeleteRoleAccess(int roleId)
        {
             _db.CRoleAccesses.Where(r => r.RoleId == roleId).ToList().ForEach(r => _db.CRoleAccesses.Remove(r));
        }

        public bool RoleExists(int roleId)
        {
            return _db.CRoles.Any(u => u.Id == roleId);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
