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
                    return Redirect(ReturnUrl);
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


        
    }
}