using System.Net;

namespace BulbasaurAPI.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;

            if (context.Request.Path == "/api/login")
            {
                await _next(context);
                return;
            }

            try
            {
                var authorizationHeader = context.Request.Headers.Authorization;

                if (string.IsNullOrEmpty(authorizationHeader))
                {
                    await ReturnErrorResponse(context);
                    return;
                }

                string accessToken = authorizationHeader[0].Split(' ')[1];

                if (await CheckAccessToken(accessToken))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    await ReturnErrorResponse(context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AuthenticationMiddleware: ", ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Error when authenticating user.");
            }
        }

        private async Task<bool> CheckAccessToken(string token)
        {
            return true;
        }

        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Invalid access token.");
        }
    }
}