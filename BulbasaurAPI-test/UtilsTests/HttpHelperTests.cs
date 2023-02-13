using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;
using HttpContextMoq;
using HttpContextMoq.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BulbasaurAPI_test.UtilsTests
{
    public class HttpHelperTests
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

        [Fact]
        public void GetIpAddress_XForwardedForIp()
        {
            var httpContextMock = new HttpContextMock();
            httpContextMock.SetupRequestHeaders(new Dictionary<string, StringValues> { { "X-Forwarded-For", _testIp } });

            var ipAddress = HttpHelper.GetIpAddress(httpContextMock);

            Assert.NotNull(ipAddress);
            Assert.Equal(_testIp, ipAddress);
        }

        [Fact]
        public void GetIpAddress_GetIpFromConnection()
        {
            var httpContextMock = new HttpContextMock();
            httpContextMock.ConnectionMock.Mock.Setup(m => m.RemoteIpAddress).Returns(IPAddress.Parse(_testIp));

            var ipAddress = HttpHelper.GetIpAddress(httpContextMock);

            Assert.NotNull(ipAddress);
            Assert.Equal(_testIp, ipAddress);
        }

        [Fact]
        public void GetRequestUser_ReturnsUser()
        {
            var httpContextMock = new HttpContextMock();
            httpContextMock.ItemsMock.Mock.Setup(m => m["User"]).Returns(_testUser);

            var user = HttpHelper.GetRequestUser(httpContextMock);

            Assert.NotNull(user);
            Assert.Equal(_testUser.Id, user.Id);
            Assert.Equal(_testUser.Username, user.Username);
            Assert.Equal(_testUser.Password, user.Password);
            Assert.Equal(_testUser.AccessLevel, user.AccessLevel);
            Assert.Equal(_testUser.Person.Id, user.Person.Id);
            Assert.Equal(_testUser.Person.FullName, user.Person.FullName);
            Assert.Equal(_testUser.Person.Role.Id, user.Person.Role.Id);
            Assert.Equal(_testUser.Person.Role.Name, user.Person.Role.Name);
        }

        [Fact]
        public void GetRequestUser_NoUserReturnsNull()
        {
            var httpContextMock = new HttpContextMock();

            var user = HttpHelper.GetRequestUser(httpContextMock);

            Assert.Null(user);
        }
    }
}