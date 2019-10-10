using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hozor.Utilities.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hozor.Web.Controllers
{

    [Authorize]
    public class BaseController : Controller
    {
        protected void Success(string message = "عمليات با موفقيت انجام شد", string color = "success")
        {
            TempData[Constants.MessageKey] = message;
            TempData[Constants.ColorKey] = color;
        }

        protected void Warning(string message = "آيتمي يافت نشد", string color = "warning")
        {
            TempData[Constants.MessageKey] = message;
            TempData[Constants.ColorKey] = color;
        }

        protected void Erorr(string message = "متاسفانه خطايي رخ داده است", string color = "danger")
        {
            TempData[Constants.MessageKey] = message;
            TempData[Constants.ColorKey] = color;
        }

        protected void Info(string message, string color = "info")
        {
            TempData[Constants.MessageKey] = message;
            TempData[Constants.ColorKey] = color;
        }
    }
}