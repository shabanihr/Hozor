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
using Hozor.ViewModels.Public;

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
            return View(_userRep.GetAllUsers());
        }

        // GET: CUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = _userRep.GetUserById(id.Value);
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
                users.RegisterDate = DateTime.Now;
                
                //Hash Password
                var data = Encoding.ASCII.GetBytes(users.Password);
                var md5 = new MD5CryptoServiceProvider();
                var md5data = md5.ComputeHash(data);
                users.Password= new string(new ASCIIEncoding().GetChars(md5data));

                _userRep.InsertUser(users);
                 await _userRep.Save();
                Success();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: CUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = _userRep.GetUserById(id.Value);
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
                    _userRep.UpdateUser(users);
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

        // POST: CUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _userRep.DeleteUser(id.Value);
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
            return View("Index", _userRep.FilterUser(userName, isActive, startDate, endDate));
        }

        private bool CUsersExists(int id)
        {
            return _userRep.UserExists(id);
        }
    }
}
