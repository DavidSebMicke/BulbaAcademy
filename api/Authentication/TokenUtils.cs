using BulbasaurAPI.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BulbasaurAPI.Authentication
{
    public class TokenUtils
    {
        // Generate an access token, unique for each user and for each time it is issued
        public static async Task<string> GenerateAccessToken(User user, string ipAddress, DbServerContext db)
        {
            // Generate token through JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("guid", user.GUID.ToString()), new Claim("identifier", GetRandomIdentifier()) }),
                Expires = DateTime.UtcNow.AddMinutes(AccessToken.MaximumSessionMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string accessToken = tokenHandler.WriteToken(token);

            try
            {
                await db.AccessTokens.AddAsync(new AccessToken()
                {
                    TokenStr = Hasher.Hash(accessToken),
                    IpAddress = ipAddress,
                    User = user,
                    IssuedDateTime = DateTime.Now,
                    LastUsedDateTime = DateTime.Now,
                });
                await db.SaveChangesAsync();
            }
            catch
            {
                return "";
            }

            return accessToken;
        }

        // Authenticates an accesstoken. Returns a user if it is valid, null if it is not
        public static async Task<User?> AuthenticateToken(string accessToken, string ipAddress)
        {
            if (accessToken == null) return null;

            using var db = new DbServerContext();

            AccessToken dbToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

            try
            {
                // Standard access token validation
                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userGUID = Guid.Parse(jwtToken.Claims.First(c => c.Type == "guid").Value);

                // Access token authentication through backend
                dbToken = await db.AccessTokens.Include(a => a.User).FirstAsync(t => t.TokenStr == Hasher.Hash(accessToken));
            }
            catch
            {
                return null;
            }

            // Check if dbtoken exists
            if (dbToken == null) return null;

            // Check if IP is the same as the token is issued to
            if (ipAddress != dbToken.IpAddress) return null;

            // Check if token is still valid
            TimeSpan issuedSpan = DateTime.Now - dbToken.IssuedDateTime;
            if (issuedSpan.TotalMinutes >= AccessToken.MaximumSessionMinutes) return null;

            // Check if session is still valid
            TimeSpan lastUsedSpan = DateTime.Now - dbToken.LastUsedDateTime;
            if (lastUsedSpan.TotalMinutes >= AccessToken.MaximumIdleMinutes) return null;

            return dbToken.User;
        }

        // Generate an Two F token, unique for each user and for each time it is issued
        public static async Task<string> GenerateTwoFToken(User user, string ipAddress, DbServerContext db)
        {
            // Generate token through JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("guid", user.GUID.ToString()), new Claim("identifier", GetRandomIdentifier()) }),
                Expires = DateTime.UtcNow.AddMinutes(TwoFToken.MaximumSessionMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string twoFToken = tokenHandler.WriteToken(token);

            try
            {
                await db.TwoFTokens.AddAsync(new TwoFToken()
                {
                    TokenStr = Hasher.Hash(twoFToken),
                    IpAddress = ipAddress,
                    User = user,
                    IssuedDateTime = DateTime.Now,
                    LastUsedDateTime = DateTime.Now,
                });

                await db.SaveChangesAsync();
            }
            catch
            {
                return "";
            }

            return twoFToken;
        }

        // Authenticates a two factor token. Returns a user if it is valid, null if it is not
        public static async Task<User?> AuthenticateTwoFToken(string token, string ipAddress)
        {
            if (token == null) return null;

            using var db = new DbServerContext();

            TwoFToken dbToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

            try
            {
                // Standard Two F token validation
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userGUID = Guid.Parse(jwtToken.Claims.First(c => c.Type == "guid").Value);

                // Access token authentication through backend
                dbToken = await db.TwoFTokens.Include(a => a.User).FirstAsync(t => t.TokenStr == Hasher.Hash(token));
            }
            catch
            {
                return null;
            }

            // Check if dbtoken exists
            if (dbToken == null) return null;

            // Check if IP is the same as the token is issued to
            if (ipAddress != dbToken.IpAddress) return null;

            // Check if token is still valid
            TimeSpan issuedSpan = DateTime.Now - dbToken.IssuedDateTime;
            if (issuedSpan.TotalMinutes >= AccessToken.MaximumSessionMinutes) return null;

            // Check if session is still valid
            TimeSpan lastUsedSpan = DateTime.Now - dbToken.LastUsedDateTime;
            if (lastUsedSpan.TotalMinutes >= AccessToken.MaximumIdleMinutes) return null;

            return dbToken.User;
        }

        // HELP METHODS
        // Gets a random token identifier
        private static string GetRandomIdentifier()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}