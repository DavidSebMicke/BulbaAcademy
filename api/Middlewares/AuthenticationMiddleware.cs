using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;
using System.Net;

namespace BulbasaurAPI.Middlewares
{
    public class AuthenticationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string[] unAuthenticatedPaths = new string[]
            {
                "/api/Authentication/login",
                "/api/Authentication/createUserTEST",
                "/api/Authentication/login/totp",
                "/api/recaptcha"
            };
            // Skip unauthenticated paths
            if (unAuthenticatedPaths.Any(s => s.ToLower() == context.Request.Path.ToString().ToLower()))
            {
                await next(context);
                return;
            }

            try
            {
                if (!context.Request.Headers.Any(h => h.Key == "Authorization"))
                {
                    await ReturnErrorResponse(context, "Authorization header missing.");
                    return;
                }

                var authorizationHeader = context.Request.Headers.Authorization;
                var ipAddress = HttpHelper.GetIpAddress(context);

                if (string.IsNullOrEmpty(authorizationHeader) || string.IsNullOrEmpty(ipAddress))
                {
                    await ReturnErrorResponse(context, "Empty Authorization header or invalid IP.");
                    return;
                }

                string accessToken = authorizationHeader[0].Split(' ')[1];

                Console.WriteLine("accesstoken:" + accessToken);

                using var db = new ContextFactory().CreateContext();

                User? user = await TokenUtils.AuthenticateAccessToken(accessToken, ipAddress, db);

                if (user != null)
                {
                    // Attaches user to the request-context, making it possible to use it for authorization later on
                    context.Items["User"] = user;
                    await next.Invoke(context);
                }
                else
                {
                    await ReturnErrorResponse(context);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AuthenticationMiddleware: ", ex);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Error when authenticating user.");
            }
        }

        //Returns errormessage for invalid access token
        private async Task ReturnErrorResponse(HttpContext context, string message = "Invalid access token.")
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync(message);
        }
    }
}