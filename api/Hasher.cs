using System.Security.Cryptography;

namespace BulbasaurAPI
{
    internal static class Hasher
    {
        private static int _saltLength = 16;

        internal static string Hash(string str)
        {

            return BCrypt.Net.BCrypt.EnhancedHashPassword(str);
        }

        internal static string HashWithSalt(string str, out string salt)
        {
            salt = Salt();

            return BCrypt.Net.BCrypt.EnhancedHashPassword(salt + str);
        }
        internal static bool Verify(string input, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(input, hash);
        }
        private static string Salt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(_saltLength);

        }
    }
}
