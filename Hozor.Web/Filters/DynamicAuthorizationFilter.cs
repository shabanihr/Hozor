using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Hozor.Web.Filters
{
    public class DynamicAuthorizationFilter : IAsyncAuthorizationFilter
    {

        private readonly Hozor_DBContext _dbContext;
        private string _requestControllerName;
        private string _requestedActionName;

        public DynamicAuthorizationFilter(Hozor_DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {

            if (!IsProtectedAction(context))
                return;

            if (!IsUserAuthenticated(context))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var actionId = GetActionId(context);
            var userName = context.HttpContext.User.Identity.Name;

            var roleAccess = from ra in _dbContext.CRoleAccesses
                             let userId = _dbContext.CUsers.FirstOrDefault(u => u.UserName == userName).Id
                             let roleIds = _dbContext.CRoles.Where(r => r.CU.Any(u => u.UserId == userId)).Select(r => r.Id)
                             where roleIds.Contains(ra.RoleId)
                             select ra;

            if (roleAccess.Any(ra =>
                ra.Controller.Equals(_requestControllerName, StringComparison.InvariantCultureIgnoreCase) &&
                ra.Action.Equals(_requestedActionName, StringComparison.InvariantCultureIgnoreCase)))
                return;

            //var roles = await (
            //    from user in _dbContext.CUsers
            //    join userRole in _dbContext.CUsersRoles on user.Id equals userRole.UserId
            //    join role in _dbContext.CRoles on userRole.RoleId equals role.Id
            //    where user.UserName == userName
            //    select role
            //).ToListAsync();
            //foreach (var role in roleAccess)
            //{
            //    var accessList = roleAccess<IEnumerable<CMvcControllerInfo>>(role.Access);
            //    if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
            //        return;
            //}

            context.Result = new ForbidResult();
        }

        private bool IsProtectedAction(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return false;

            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
            var actionMethodInfo = controllerActionDescriptor.MethodInfo;

            var authorizeAttribute = controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            authorizeAttribute = actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            return false;
        }

        private bool IsUserAuthenticated(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        private string GetActionId(AuthorizationFilterContext context)
        {
            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var area = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute<AreaAttribute>()?.RouteValue;
            var controller = controllerActionDescriptor.ControllerName;
            var action = controllerActionDescriptor.ActionName;

            return $"{area}:{controller}:{action}";
        }
    }
}
