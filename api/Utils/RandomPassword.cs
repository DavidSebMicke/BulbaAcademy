namespace BulbasaurAPI.Utils
{
    public static class RandomPassword
    {
        //super ugly but works
        public static string GenerateRandomPassword(int lowerCases = 3, int upperCases = 3, int numbers = 3, int specials = 1)
        {
            int length = lowerCases + upperCases + numbers + specials;
            if (length == 0) return "";

            string result = "";

            string[] strings = new string[]
            {
                "abcdefghijkmnopqrstuvwxyz",
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "!@#$%&*-?",
                "1234567890"
            };

            Dictionary<int, int> charKeys = new Dictionary<int, int>()
            {
                {0, lowerCases},
                {1, upperCases},
                {2, specials},
                {3, numbers},
            };

            Random random = new Random();

            while (result.Length < length || charKeys.Count > 0)
            {
                var charKey = charKeys.ElementAt(random.Next(0, charKeys.Count)).Key;

                charKeys[charKey]--;
                if (charKeys[charKey] <= 0) charKeys.Remove(charKey);

                result += RandomChar(strings[charKey]);
            }

            return result;
        }

        private static char RandomChar(string chars)
        {
            Random random = new Random();

            return chars[random.Next(chars.Length)];
        }
    }
}