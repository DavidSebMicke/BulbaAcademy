namespace BulbasaurAPI.Helpers
{
    public class HttpHelper
    {

        // Get IP address
        public static string GetIpAddress(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                return context.Request.Headers["X-Forwarded-For"];
            else
                return context.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

    }
}
