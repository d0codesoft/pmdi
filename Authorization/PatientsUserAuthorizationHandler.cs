using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using pmdi.Areas.Identity.Data;
using pmdi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pmdi.Authorization
{

    public class PatientsUserAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Patients>
    {
        UserManager<WebAppUser> _userManager;

        public PatientsUserAuthorizationHandler(UserManager<WebAppUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Patients resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            var usr = _userManager.GetUserAsync(context.User);
            usr.Wait();

            if (resource.UserId == usr.Result.Id)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class PatientsAdministratorsAuthorizationHandler
                : AuthorizationHandler<OperationAuthorizationRequirement, Patients>
    {
        protected override Task HandleRequirementAsync(
                                     AuthorizationHandlerContext context,
                                     OperationAuthorizationRequirement requirement,
                                     Patients resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.AdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

}
