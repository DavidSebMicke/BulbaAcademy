namespace BulbasaurAPI
{
    internal static class Hasher
    {
        internal static string Hash(string str)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(str);
        }
        internal static bool Verify(string input, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(input, hash);
        }
    }
}
