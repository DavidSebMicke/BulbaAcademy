using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BulbasaurAPI.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        // Lowest access level
        public string AccessLevel { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // If there is no lowest access level then everyone can access it
            if (string.IsNullOrEmpty(AccessLevel)) return;

            bool validAccessLevel = Enum.TryParse(AccessLevel, out UserAccessLevel accessLevel);

            var user = (User)context.HttpContext.Items["User"];

            if (user == null || !validAccessLevel || (int)user.AccessLevel < (int)accessLevel)
            {
                SendUnauthorizedMessage(context);
            }
            else
            {
                return;
            }
        }

        public async void SendUnauthorizedMessage(AuthorizationFilterContext context)
        {
            context.Result = new JsonResult(new { message = "You are not authorized to access this content." }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}