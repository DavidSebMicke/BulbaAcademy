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
        public static async Task<string> GenerateAccessToken(User user, string ipAddress)
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

            using var db = new DbServerContext();
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

            }
            catch
            {
                return "";
            }

            return accessToken;
        }

        // Generate an Two F token, unique for each user and for each time it is issued
        public static async Task<string> GenerateTwoFToken(User user, string ipAddress)
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

            using var db = new DbServerContext();
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

                
            }
            catch
            {
                return "";
            }

            return twoFToken;
        }





        // Gets a random token identifier
        private static string GetRandomIdentifier()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
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
    }
}