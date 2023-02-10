using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;

namespace BulbasaurAPI.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private DbServerContext _context;

        public LoggingMiddleware(DbServerContext context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = context.Request.Path;
            var requestType = context.Request.Method;
            var ipAddress = HttpHelper.GetIpAddress(context);
            var accessToken = context.Response.Headers.Authorization;
            User? user = null;

            if (!string.IsNullOrEmpty(accessToken))
            {
                user = await TokenUtils.AuthenticateAccessToken(accessToken, ipAddress, _context);
            }

            var logging = new Logging()
            {
                Action = $"{requestType}: {path}",
                User = user,
                IpAddress = ipAddress,
            };

            _context.Loggs.Add(logging);
            await _context.SaveChangesAsync();
        }
    }
}