using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.DomainClasses.Public;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hozor.Web.Filters
{
    [HtmlTargetElement("secure-content")]
    public class SecureContentTagHelper : TagHelper
    {
        private readonly Hozor_DBContext _dbContext;

        public SecureContentTagHelper(Hozor_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HtmlAttributeName("asp-area")]
        public string Area { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            var user = ViewContext.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                output.SuppressOutput();
                return;
            }


            var roleAccess = await (
                from users in _dbContext.CUsers
                join userRole in _dbContext.CUsersRoles on users.Id equals userRole.UserId
                join role in _dbContext.CRoles on userRole.RoleId equals role.Id
                join ra in _dbContext.CRoleAccesses on role.Id equals ra.RoleId
                where users.UserName == user.Identity.Name
                select ra
            ).ToListAsync();

          //  var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            if (roleAccess.Any(ra =>
                ra.Controller.Equals(Controller) &&
                ra.Action.Equals(Action)))
                return;

            //var roles = await (
            //    from usr in _dbContext.Users
            //    join userRole in _dbContext.UserRoles on usr.Id equals userRole.UserId
            //    join role in _dbContext.Roles on userRole.RoleId equals role.Id
            //    where usr.UserName == user.Identity.Name
            //    select role
            //).ToListAsync();

            //var actionId = $"{Area}:{Controller}:{Action}";

            //foreach (var role in roles)
            //{
            //    if (role.Access == null)
            //        continue;

            //    var accessList = JsonConvert.DeserializeObject<IEnumerable<CMvcControllerInfo>>(role.Access);
            //    if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
            //        return;
            //}

            output.SuppressOutput();
        }
    }
}
