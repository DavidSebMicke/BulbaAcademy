﻿using BulbasaurAPI.Authentication;
using BulbasaurAPI.Models;
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
                var ipAddress = GetIpAddress(context);

                if (string.IsNullOrEmpty(authorizationHeader) || string.IsNullOrEmpty(ipAddress))
                {
                    await ReturnErrorResponse(context);
                    return;
                }

                string accessToken = authorizationHeader[0].Split(' ')[1];

                User? user = await TokenUtils.AuthenticateToken(accessToken, ipAddress);

                if (user != null)
                {
                    // Attaches user to the request-context, making it possible to use it for authorization later on
                    context.Items["User"] = user;
                    await _next.Invoke(context);
                }
                else
                {
                    await ReturnErrorResponse(context);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AuthenticationMiddleware: ", ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Error when authenticating user.");
            }
        }

        // Get IP address
        private string GetIpAddress(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                return context.Request.Headers["X-Forwarded-For"];
            else
                return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        //Returns errormessage for invalid access token
        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Invalid access token.");
        }
    }
}