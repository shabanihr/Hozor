using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using System.Text;
using System.Security.Cryptography;
using Hozor.Utilities.Helpers;
using Hozor.ViewModels.Public;
using Microsoft.AspNetCore.Authorization;

namespace Hozor.Web.Controllers
{

    public class CUsersController : BaseController
    {
        private readonly IUserRep _userRep;

        public CUsersController(IUserRep userRep)
        {
            _userRep = userRep;
        }

        // GET: CUsers
        public async Task<IActionResult> Index()
        {
            ViewBag.isActive = false;
            ViewBag.ShowFilter = false;
            return View(await _userRep.GetAllUsers());
        }

        // GET: CUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _userRep.GetUserById(id.Value);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: CUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,IsActive,RegisterDate")] CUsers users)
        {
            if (ModelState.IsValid)
            {
                string result = await _userRep.AnyUser‍Insert(users);
                if (result != "True")
                {
                    users.RegisterDate = DateTime.Now;

                    //Hash Password
                    users.Password = HashPassword.ToHashPassword(users.Password);

                    await _userRep.InsertUser(users);
                    await _userRep.Save();
                    Success();
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("UserName", " اين نام كاربري قبلاً در سيستم ثبت شده است");


            }
            RegisterViewModel viewModelUser = new RegisterViewModel();
            viewModelUser.UserName = users.UserName;
            viewModelUser.IsActive = users.IsActive;
            viewModelUser.Password = users.Password;
            return View(viewModelUser);
        }

        // GET: CUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _userRep.GetUserById(id.Value);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: CUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,IsActive")] CUsers users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string result = await _userRep.AnyUser‍Update(users);
                    if (result != "True")
                    {
                        await _userRep.UpdateUser(users);
                        await _userRep.Save();
                        Success();
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", " اين نام كاربري قبلاً در سيستم ثبت شده است");
                        return View(users);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CUsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // POST: CUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _userRep.DeleteUser(id.Value);
            await _userRep.Save();
            Success();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter(string userName = "", bool isActive = false, string startDate = "", string endDate = "")
        {
            ViewBag.userName = userName;
            ViewBag.isActive = isActive;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;
            ViewBag.ShowFilter = true;
            return View("Index", await _userRep.FilterUser(userName, isActive, startDate, endDate));
        }


        // GET: CUsers/ChangePassword/5
        public async Task<IActionResult> ChangePassword(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _userRep.GetUserById(id.Value);
            if (users == null)
            {
                return NotFound();
            }

            ViewBag.UserName = users.UserName;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(int id, ChangePasswordViewModel users)
        {
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Hash Password
                    users.Password = HashPassword.ToHashPassword(users.Password);

                    await _userRep.ChangePassword(users);
                    await _userRep.Save();
                    Success();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CUsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }


        private bool CUsersExists(int id)
        {
            return _userRep.UserExists(id);
        }
    }
}
