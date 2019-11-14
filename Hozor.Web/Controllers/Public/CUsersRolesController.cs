using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hozor.DataLayer.Models;
using Hozor.ViewModels.Public;

namespace Hozor.Web.Controllers
{
    [DisplayName("دسترسي كاربران")]
    public class CUsersRolesController : BaseController
    {
        private readonly Hozor_DBContext _context;

        public CUsersRolesController(Hozor_DBContext context)
        {
            _context = context;
        }

        // GET: CUsersRoles
        [DisplayName("ليست دسترسي كاربران")]
        public IActionResult Index()
        {
            var users = (from u in _context.CUsers
                select new
                {
                    UserId = u.Id,
                    u.UserName,
                    Roles = _context.CRoles.Where(r => r.CUsersRoles.Any(ur => ur.UserId == u.Id)).Select(r => r.RoleName).ToList()
                }).Select(ra => new UserRoleViewModel
            {
                UserId = ra.UserId,
                UserName = ra.UserName,
                Roles = ra.Roles
            }).ToList();
            return View(users);
        }


        // GET: CUsersRoles/Edit/5
        [DisplayName("ويرايش دسترسي كاربران")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = (from u in _context.CUsers
                select new
                {
                    UserId = u.Id,
                    u.UserName,
                    Roles = _context.CRoles.Where(r => r.CUsersRoles.Any(ur => ur.UserId == u.Id)).Select(r => r.RoleName).ToList()
                }).SingleOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();

            var roles = _context.CRoles.ToList();

            var viewModel = new EditUserRoleViewModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                SelectedRoles = user.Roles,
                Roles = roles
            };

            return View(viewModel);

        }

        // POST: CUsersRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditUserRoleViewModel viewModel, int id)
        {

            if (ModelState.IsValid)
            {
                var user = _context.CUsers.Find(viewModel.UserId);
                    _context.CUsersRoles.Where(r => r.UserId == viewModel.UserId).ToList().ForEach(r => _context.CUsersRoles.Remove(r));
                    foreach (var roleId in viewModel.SelectedRoles)
                    {
                        int roleID = Convert.ToInt32(roleId);
                        user.CUsersRoles.Add(new CUsersRoles()
                        {
                            RoleId = roleID,
                            UserId = viewModel.UserId
                        });
                    }
                    _context.SaveChanges();
                    Success();
                    return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Edit", id);
        }

    }
}
