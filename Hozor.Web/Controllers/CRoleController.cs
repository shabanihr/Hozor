using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Hozor.ViewModels.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hozor.Web.Controllers
{

    [DisplayName("گروه های کاربری")]
    public class CRoleController : BaseController
    {
        private readonly Hozor_DBContext _db;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;

        public CRoleController(IMvcControllerDiscovery mvcControllerDiscovery,
            Hozor_DBContext db)
        {
            _mvcControllerDiscovery = mvcControllerDiscovery;
            _db = db;
        }



        [DisplayName("لیست گروه کاربری")]
        public async Task<IActionResult> Index()
        {
            return View(_db.CRoles.OrderByDescending(o => o.Id).ToList());
        }

        // GET: Role/Create
        [DisplayName("ایجاد گروه کاربری جدید")]
        public async Task<ActionResult> Create()
        {
            ViewData["Controllers"] =_mvcControllerDiscovery.GetControllers();

            return View();
        }


        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
                return View(viewModel);
            }

            //جديد

            bool isRole = _db.CRoles.Any(r => r.RoleName == viewModel.Name);
            int id = _db.CRoles.Select(u => u.Id).LastOrDefault();
            id++;
            if (!isRole)
            {
                CRoles role = new CRoles()
                {
                    Id = id,
                    RoleName = viewModel.Name,
                    RoleTitle = "jj"
                };
                _db.CRoles.Add(role);
                _db.SaveChanges();
                //db.Dispose();

                int roleId = _db.CRoles.Where(r => r.RoleName == viewModel.Name).Select(r => r.Id).Single();

                foreach (var controller in viewModel.SelectedControllers)
                {
                    foreach (var action in controller.Actions)
                    {
                        _db.CRoleAccesses.Add(new CRoleAccesses { Controller = controller.Name, Action = action.Name, RoleId = roleId });
                    }
                }

                _db.SaveChanges();
                Success();
                return RedirectToAction("Index");
            }
            else
            {
                //Erorr("نام گروه کاربري وارد شده تکراري است");
            }
            return RedirectToAction("Create");

        }


        // GET: Role/Create
        [DisplayName("ويرايش گروه کاربری جدید")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            var role = _db.CRoles.Find(id);
            if (role == null)
                return NotFound();

            var viewModel = new EditRoleViewModel
            {
                Id = role.Id,
                Name = role.RoleName,
                RoleAccesses = new List<CRoleAccesses>(_db.CRoleAccesses.Where(r => r.RoleId == id)),
                Controllers = _mvcControllerDiscovery.GetControllers()
            };
            return View();
        }


        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditRoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
                return View(viewModel);
            }

            //جديد

            bool isRole = _db.CRoles.Any(r => r.RoleName == viewModel.Name && r.Id != viewModel.Id);
            if (!isRole)
            {
                var role = _db.CRoles.Find(viewModel.Id);
                role.RoleName = viewModel.Name;
                _db.Entry(role).State = EntityState.Modified;

                _db.CRoleAccesses.Where(r => r.RoleId == viewModel.Id).ToList().ForEach(r => _db.CRoleAccesses.Remove(r));
                foreach (var controller in viewModel.SelectedControllers)
                {
                    foreach (var action in controller.Actions)
                    {
                        _db.CRoleAccesses.Add(new CRoleAccesses { Controller = controller.Name, Action = action.Name, RoleId = viewModel.Id });
                    }
                }
                _db.SaveChanges();
                Success();

                return RedirectToAction("Index");
            }
            else
            {
                //Erorr("نام گروه کاربري وارد شده تکراري است");
            }
            return RedirectToAction("Create");

        }
    }
}