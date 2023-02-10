using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;
using Microsoft.OpenApi.Any;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbasaurAPI_test.UtilsTests
{
    // Testing Generation methods. Authentication methods not testable at this moment
    public class TokenUtilsTests
    {
        private readonly string _testIp = "127.0.0.1";

        private User _testUser => new User()
        {
            Id = 1,
            Username = "test@email.com",
            Password = "password123",
            AccessLevel = BulbasaurAPI.Authorization.UserAccessLevel.USER,
            Person = new Caregiver()
            {
                FirstName = "firstname",
                LastName = "lastname",
                Role = new()
                {
                    Id = 1,
                    Name = "test"
                }
            }
        };

        private readonly string _tokenSecret = "iI2k4OeIc2UavA¤UIl~@#HeyAs?i\\a!I";

        private void setTokenSecret()
        {
            TokenUtils.TokenSecretOverride = Encoding.UTF8.GetBytes(_tokenSecret);
        }

        [Fact]
        public void GenerateIdToken_ReturnsToken()
        {
            var idToken = TokenUtils.GenerateIDToken(_testUser);

            Assert.NotNull(idToken);
            Assert.IsType<string>(idToken);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(idToken);

            Assert.NotNull(jwtSecurityToken);
            Assert.Contains(jwtSecurityToken.Claims, c => c.Value == _testUser.Id.ToString());
            Assert.Contains(jwtSecurityToken.Claims, c => c.Value == _testUser.Username);
            Assert.Contains(jwtSecurityToken.Claims, c => c.Value == _testUser.Person.FullName);
            Assert.Contains(jwtSecurityToken.Claims, c => c.Value == _testUser.Person.Role.Name);
        }

        [Fact]
        public async Task GenerateAccessToken_ReturnsToken()
        {
            var mockContext = new Mock<DbServerContext>();
            mockContext.Setup(m => m.AccessTokens.AddAsync(It.IsAny<AccessToken>(), It.IsAny<CancellationToken>()));
            mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()));

            setTokenSecret();

            var accessToken = await TokenUtils.GenerateAccessToken(_testUser, _testIp, mockContext.Object);

            Assert.NotNull(accessToken);
            Assert.IsType<string>(accessToken);
            Assert.
        }

        [Fact]
        public async Task GenerateTwoFToken_ReturnsToken()
        {
            var mockContext = new Mock<DbServerContext>();
            mockContext.Setup(m => m.AccessTokens.AddAsync(It.IsAny<AccessToken>(), It.IsAny<CancellationToken>()));
            mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()));

            setTokenSecret();

            var twoFToken = await TokenUtils.GenerateTwoFToken(_testUser, _testIp, mockContext.Object);

            Assert.NotNull(twoFToken);
            Assert.IsType<string>(twoFToken);
        }
    }
}