﻿using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;

namespace BulbasaurAPI.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = context.Request.Path;
            var requestType = context.Request.Method;
            var ipAddress = HttpHelper.GetIpAddress(context);
            var accessToken = context.Response.Headers.Authorization;
            User? user = null;

            using var db = new ContextFactory().CreateContext();

            if (!string.IsNullOrEmpty(accessToken))
            {
                user = await TokenUtils.AuthenticateAccessToken(accessToken, ipAddress, db);
            }

            var logging = new Logging()
            {
                Action = $"{requestType}: {path}",
                User = user,
                IpAddress = ipAddress,
            };

            await db.Loggs.AddAsync(logging);
            await db.SaveChangesAsync();
            await next.Invoke(context);
        }
    }
}