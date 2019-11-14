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
        private readonly ICRoleRep _cRoleRep;
        private readonly IMvcControllerDiscovery _mvcControllerDiscovery;

        public CRoleController(IMvcControllerDiscovery mvcControllerDiscovery,
            ICRoleRep cRoleRep)
        {
            _mvcControllerDiscovery = mvcControllerDiscovery;
            _cRoleRep = cRoleRep;
        }



        [DisplayName("لیست گروه کاربری")]
        public async Task<IActionResult> Index()
        {
            return View(await _cRoleRep.GetAllRoles());
        }

        // GET: Role/Create
        [DisplayName("ایجاد گروه کاربری جدید")]
        public IActionResult Create()
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

            bool isRole = await _cRoleRep.IsRoleByName(viewModel.Name);
            int id = await _cRoleRep.GetTopRoleId();
            id++;
            if (!isRole)
            {
                if (viewModel.SelectedControllers != null)
                {
                    CRoles role = new CRoles()
                    {
                        Id = id,
                        RoleName = viewModel.Name,
                        RoleTitle = "jj"
                    };
                    await _cRoleRep.InsertRole(role);
                    await _cRoleRep.Save();

                    int roleId = await _cRoleRep.GetRoleSelectId(viewModel.Name);

                    foreach (var controller in viewModel.SelectedControllers)
                    {
                        foreach (var action in controller.Actions)
                        {
                            await _cRoleRep.InsertRoleAccess(new CRoleAccesses
                            { Controller = controller.Name, Action = action.Name, RoleId = roleId });
                        }
                    }

                    await _cRoleRep.Save();
                    Success();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", " لطفاً حداقل يكي از گزينه هاي ليست دسترسي زير را انتخاب كنيد");
                ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
                return View(viewModel);
            }

            ModelState.AddModelError("Name", " اين نام گروه كاربري قبلاً در سيستم ثبت شده است");
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
            return View(viewModel);
        }


        // GET: Role/Edit
        [DisplayName("ويرايش گروه کاربری")]
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();

            var role = await _cRoleRep.GetRoleById(id);
            if (role == null)
                return NotFound();

            var viewModel = new EditRoleViewModel
            {
                Id = role.Id,
                Name = role.RoleName,
                RoleAccesses = await _cRoleRep.GetRoleAccessByRoleId(id),
                Controllers = _mvcControllerDiscovery.GetControllers()
            };
            return View(viewModel);
        }


        // POST: Role/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditRoleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Controllers= _mvcControllerDiscovery.GetControllers();
                viewModel.RoleAccesses = await _cRoleRep.GetRoleAccessByRoleId(0);
                return View(viewModel);
            }

            //جديد

            bool isRole = await _cRoleRep.IsRoleById(viewModel.Name, viewModel.Id);
            if (!isRole)
            {
                if (viewModel.SelectedControllers != null)
                {
                    var role = await _cRoleRep.GetRoleById(viewModel.Id);
                    role.RoleName = viewModel.Name;
                    await _cRoleRep.UpdateRole(role);

                    await _cRoleRep.DeleteRoleAccess(viewModel.Id);
                    foreach (var controller in viewModel.SelectedControllers)
                    {
                        foreach (var action in controller.Actions)
                        {
                            await _cRoleRep.InsertRoleAccess(new CRoleAccesses
                                {Controller = controller.Name, Action = action.Name, RoleId = viewModel.Id});
                        }
                    }

                    await _cRoleRep.Save();
                    Success();

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", " لطفاً حداقل يكي از گزينه هاي ليست دسترسي زير را انتخاب كنيد");
                viewModel.Controllers = _mvcControllerDiscovery.GetControllers();
                viewModel.RoleAccesses = await _cRoleRep.GetRoleAccessByRoleId(0);
                return View(viewModel);
            }
            ModelState.AddModelError("Name", " اين نام گروه كاربري قبلاً در سيستم ثبت شده است");
            ViewData["Controllers"] = _mvcControllerDiscovery.GetControllers();
            return View(viewModel);

        }



        [DisplayName("حذف گروه كاربري")]
        // POST: CRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _cRoleRep.GetRoleById(id.Value);
            bool result = await _cRoleRep.IsUserRole(id.Value);
            if (result)
            {
                return Json(new { success = false });

            }

            await _cRoleRep.DeleteRoleAccess(id.Value);
            await _cRoleRep.DeleteRole(role);
            await _cRoleRep.Save();
            return Json(new { success = true });

        }

        private bool CRoleExists(int id)
        {
            return _cRoleRep.RoleExists(id);
        }


       
    }
}