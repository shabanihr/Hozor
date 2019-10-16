using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Hozor.ViewModels.Public;
using Microsoft.AspNetCore.Mvc;

namespace Hozor.Web.Controllers
{
    public class CRoleController : Controller
    {
        private readonly Hozor_DBContext _db;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;
        //private readonly RoleManager<CRoles> _roleManager;

        public CRoleController(IMvcControllerDiscovery mvcControllerDiscovery,
            Hozor_DBContext db/*, RoleManager<CRoles> roleManager*/)
        {
            _mvcControllerDiscovery = mvcControllerDiscovery;
            _db = db;
            //_roleManager = roleManager;
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

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
            int id = _db.CRoles.Select(u => u.Id).FirstOrDefault();
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
                //Success();
                return RedirectToAction("Index");
            }
            else
            {
                //Erorr("نام گروه کاربري وارد شده تکراري است");
            }
            return RedirectToAction("Create");


            //جديد


            //var role = new CApplicationRole { RoleName = viewModel.Name };
            //if (viewModel.SelectedControllers != null && viewModel.SelectedControllers.Any())
            //{
            //    foreach (var controller in viewModel.SelectedControllers)
            //    foreach (var action in controller.Actions)
            //        action.ControllerId = controller.Id;

            //    var accessJson = JsonConvert.SerializeObject(viewModel.SelectedControllers);
            //    role.Access = accessJson;
            //}

            ////var result = await _roleManager.CreateAsync(role);
            ////if (result.Succeeded)
            ////    return RedirectToAction(nameof(Index));

            ////foreach (var error in result.Errors)
            ////    ModelState.AddModelError("", error.Description);

            ////ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            //return View(viewModel);
        }
    }
}