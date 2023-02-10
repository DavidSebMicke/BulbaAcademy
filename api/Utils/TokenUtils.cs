using BulbasaurAPI.Database;
using BulbasaurAPI.DTOs.UserDTOs;
using BulbasaurAPI.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BulbasaurAPI.Utils
{
    public class TokenUtils
    {
        public static byte[]? TokenSecretOverride { get; set; } = null;

        // Generates an Id token with user/person info
        public static string GenerateIDToken(User user)
        {
            if (user == null) return "";

            // Generate token through JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("userID", user.Id.ToString()),
                    new Claim("email", user.Username),
                    new Claim("accessLevel", user.AccessLevel.ToString()),
                    new Claim("name", user.Person != null ? user.Person?.FullName : ""),
                    new Claim("role", user.Person != null ? user.Person?.Role.Name : ""),
                }),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string idToken = tokenHandler.WriteToken(token);

            return idToken;
        }

        // Generate an access token, unique for each user and for each time it is issued
        public static async Task<string> GenerateAccessToken(User user, string ipAddress, DbServerContext db)
        {
            // Generate token through JwtSecurityTokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = TokenSecretOverride ?? Encoding.UTF8.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

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
                    TokenStr = accessToken,
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
        public static async Task<User?> AuthenticateAccessToken(string accessToken, string ipAddress, DbServerContext db)
        {
            if (accessToken == null) return null;

            AccessToken dbToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

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
                dbToken = await db.AccessTokens.Include(a => a.User).ThenInclude(u => u.Person).FirstAsync(t => t.TokenStr == accessToken);
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
            var key = TokenSecretOverride ?? Encoding.UTF8.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

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
                    TokenStr = twoFToken,
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
        public static async Task<bool> AuthenticateTwoFToken(string token, string ipAddress, DbServerContext db)
        {
            if (token == null) return false;

            TwoFToken dbToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = TokenSecretOverride ?? Encoding.UTF8.GetBytes(DotEnv.Read()["TOKEN_SECRET"]);

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
                dbToken = await db.TwoFTokens.Include(a => a.User).ThenInclude(u => u.Person).FirstAsync(t => t.TokenStr == token);
            }
            catch
            {
                return false;
            }

            // Check if dbtoken exists
            if (dbToken == null) return false;

            // Check if IP is the same as the token is issued to
            if (ipAddress != dbToken.IpAddress) return false;

            // Check if token is still valid
            TimeSpan issuedSpan = DateTime.Now - dbToken.IssuedDateTime;
            if (issuedSpan.TotalMinutes >= AccessToken.MaximumSessionMinutes) return false;

            // Check if session is still valid
            TimeSpan lastUsedSpan = DateTime.Now - dbToken.LastUsedDateTime;
            if (lastUsedSpan.TotalMinutes >= AccessToken.MaximumIdleMinutes) return false;

            return dbToken.User != null;
        }

        // HELP METHODS
        // Gets a random token identifier
        private static string GetRandomIdentifier()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}