using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.DomainClasses.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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


            var userName = context.HttpContext.User.Identity.Name;

            var roleAccess = await (
                from user in _dbContext.CUsers
                join userRole in _dbContext.CUsersRoles on user.Id equals userRole.UserId
                join role in _dbContext.CRoles on userRole.RoleId equals role.Id
                join ra in _dbContext.CRoleAccesses on role.Id equals ra.RoleId 
                where user.UserName == userName
                select ra
            ).ToListAsync();

            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            if (roleAccess.Any(ra =>
                ra.Controller.Equals(controllerActionDescriptor.ControllerName) &&
                ra.Action.Equals(controllerActionDescriptor.ActionName)))
                return;

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
