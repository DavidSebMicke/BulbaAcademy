using BulbasaurAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbasaurAPI_test.UtilsTests
{
    public class RandomPasswordTests
    {
        private Dictionary<string, string> characters = new Dictionary<string, string>
        {
            { "lowers", "abcdefghijkmnopqrstuvwxyz" },
            { "uppers",    "ABCDEFGHJKLMNOPQRSTUVWXYZ" },
            { "specials",   "!@#$%&*-?" },
            { "numbers",    "1234567890" }
        };

        [Fact]
        public void GenerateRandomPassword_DefaultInputParams()
        {
            int defLowers = 3;
            int defUppers = 3;
            int defNumbers = 3;
            int defSpecials = 1;
            int defLength = defLowers + defUppers + defNumbers + defSpecials;

            var password = RandomPassword.GenerateRandomPassword();

            Assert.NotEmpty(password);
            Assert.Equal(defLength, password.Length);

            foreach (char c in password)
            {
                if (characters["lowers"].Contains(c)) defLowers--;
                if (characters["uppers"].Contains(c)) defUppers--;
                if (characters["numbers"].Contains(c)) defNumbers--;
                if (characters["specials"].Contains(c)) defSpecials--;
            }

            // All counts should be 0 after the above loop
            Assert.Equal(0, defLowers);
            Assert.Equal(0, defUppers);
            Assert.Equal(0, defNumbers);
            Assert.Equal(0, defSpecials);
        }

        [Fact]
        public void GenerateRandomPassword_CustomInputParams()
        {
            int defLowers = 2;
            int defUppers = 9;
            int defNumbers = 14;
            int defSpecials = 5;
            int defLength = defLowers + defUppers + defNumbers + defSpecials;

            var password = RandomPassword.GenerateRandomPassword(defLowers, defUppers, defNumbers, defSpecials);

            Assert.NotEmpty(password);
            Assert.Equal(defLength, password.Length);

            foreach (char c in password)
            {
                if (characters["lowers"].Contains(c)) defLowers--;
                if (characters["uppers"].Contains(c)) defUppers--;
                if (characters["numbers"].Contains(c)) defNumbers--;
                if (characters["specials"].Contains(c)) defSpecials--;
            }

            // All counts should be 0 after the above loop
            Assert.Equal(0, defLowers);
            Assert.Equal(0, defUppers);
            Assert.Equal(0, defNumbers);
            Assert.Equal(0, defSpecials);
        }

        [Fact]
        public void GenerateRandomPassword_EmptyPassword()
        {
            int defLowers = 0;
            int defUppers = 0;
            int defNumbers = 0;
            int defSpecials = 0;
            int defLength = defLowers + defUppers + defNumbers + defSpecials;

            var password = RandomPassword.GenerateRandomPassword(defLowers, defUppers, defNumbers, defSpecials);

            Assert.Empty(password);
            Assert.Equal(defLength, password.Length);

            foreach (char c in password)
            {
                if (characters["lowers"].Contains(c)) defLowers--;
                if (characters["uppers"].Contains(c)) defUppers--;
                if (characters["numbers"].Contains(c)) defNumbers--;
                if (characters["specials"].Contains(c)) defSpecials--;
            }

            // All counts should be 0 after the above loop
            Assert.Equal(0, defLowers);
            Assert.Equal(0, defUppers);
            Assert.Equal(0, defNumbers);
            Assert.Equal(0, defSpecials);
        }
    }
}