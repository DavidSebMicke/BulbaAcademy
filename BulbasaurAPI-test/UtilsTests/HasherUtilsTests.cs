using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbasaurAPI_test.UtilsTests
{
    public class HasherUtilsTests
    {
        private static int _saltLength = 16;
        private static string _passwordToHash = "abcde";

        [Fact]
        public void Hash_ReturnsHashedString()
        {
            //Arrange
            var result = BCrypt.Net.BCrypt.EnhancedHashPassword(_passwordToHash);

            //Act

            //Assert
            Assert.NotNull(result);
            Assert.IsType<String>(result);
            Assert.NotEqual(result, _passwordToHash);
        }

        [Fact]
        public void HashWithSalt_ReturnsHashedStringWithSalt()
        {
            //Arrange
            var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(_passwordToHash);
            var salt = BCrypt.Net.BCrypt.GenerateSalt(_saltLength);
            var result = BCrypt.Net.BCrypt.EnhancedHashPassword(salt + hashedPassword);

            //Act

            //Assert
            Assert.NotEqual(result, _passwordToHash);
            Assert.DoesNotContain(_passwordToHash, result);
            Assert.DoesNotContain(hashedPassword, result);
            Assert.NotNull(result);
        }

        [Fact]
        public void Verify_ReturnsBool()
        {
            //Arrange
            var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(_passwordToHash);
            var salt = BCrypt.Net.BCrypt.GenerateSalt(_saltLength);
            var result = BCrypt.Net.BCrypt.EnhancedHashPassword(salt + hashedPassword);
            //Act
            var verifiedResult = BCrypt.Net.BCrypt.EnhancedVerify(salt + hashedPassword, result);
            //Assert
            Assert.True(verifiedResult);
        }

        [Fact]
        public void GenerateSalt_ReturnsString()
        {
            //Arrange
            var salt = BCrypt.Net.BCrypt.GenerateSalt(_saltLength);
            int expected = 29;
            //Act

            //Assert
            Assert.NotNull(salt);
            Assert.IsType<String>(salt);
            Assert.Equal<int>(expected, salt.Length);          
        }

    }
}
