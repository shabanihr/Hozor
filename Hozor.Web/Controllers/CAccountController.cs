using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hozor.Servises.Repositoryes.Public;
using Hozor.Utilities.Helpers;
using Hozor.ViewModels.Public;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hozor.Web.Controllers
{
    [AllowAnonymous]
    public class CAccountController : BaseController
    {
        private readonly IAccountRep _accountRep;

        public CAccountController(IAccountRep accountRep)
        {
            _accountRep = accountRep;
        }


        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                //Hash Password
                login.Password = HashPassword.ToHashPassword(login.Password);

                string result = await _accountRep.Login(login);
                if (result == "Success")
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, login.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Name, login.UserName));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                    {
                        IsPersistent = false

                    });
                    return RedirectToAction("Index","Home");
                }
                if (result == "NotActive")
                {
                    ModelState.AddModelError("UserName", "حساب کاربری شما غير فعال است");
                }

                if (result == "NotFound")
                {
                    ModelState.AddModelError("UserName", "کاربری با اطلاعات وارد شده یافت نشد");
                }
            }

            return View(login);
        }

        [Route("LogOff")]
        public ActionResult LogOff()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Login");
        }



        // GET: CUsers/ChangePassword/5
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _accountRep.GetByUserName(User.Identity.Name);
            ViewBag.Id = user.Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordUserViewModel users)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _accountRep.GetByUserName(User.Identity.Name);
                    string password = HashPassword.ToHashPassword(users.OldPassword);
                    if (user.Password==password)
                    {
                        //Hash Password
                        user.Password = HashPassword.ToHashPassword(users.Password);
                        await _accountRep.ChangePasswordUser(user);
                        await _accountRep.Save();
                        Success();
                    }
                    else
                    {
                        ModelState.AddModelError("OldPassword", "رمز عبور فعلي نادرست است");
                        return View(users);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        return NotFound();

                }
                return RedirectToAction("Index","Home");
            }
            return View(users);
        }

        
    }
}