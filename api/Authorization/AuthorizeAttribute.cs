using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BulbasaurAPI.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Authorize : Attribute, IAuthorizationFilter
    {
        // Lowest access level
        public UserAccessLevel AccessLevel { get; set; }

        public bool UnAuthorized { get; set; } = false;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (UnAuthorized) return;

            var user = (User?)context.HttpContext.Items["User"];

            if (user == null || (int)user.AccessLevel < (int)AccessLevel)
            {
                SendUnauthorizedMessage(context);
            }
            else
            {
                return;
            }
        }

        public void SendUnauthorizedMessage(AuthorizationFilterContext context)
        {
            context.Result = new JsonResult(new { message = "You are not authorized to access this content." }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}