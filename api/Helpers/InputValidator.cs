using System.Text.RegularExpressions;

namespace BulbasaurAPI.Helpers
{
    public class InputValidator
    {
        public static bool ValidateEmailFormat(string str)
        {
            //to limit max length?
            if (str.Length > 255) return false;

            return Regex.IsMatch(str, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public static bool ValidatePasswordFormat(string str)
        {
            //to limit max length?
            if (str.Length > 255) return false;
            //at least 8 characters
            else if (str.Length < 8) return false;
            //at least 3 lowercase letters
            else if (!Regex.IsMatch(str, @"(?:.*[a-z]){3,}")) return false;
            //at least 3 uppercase letters
            else if (!Regex.IsMatch(str, @"(?:.*[A-Z]){3,}")) return false;
            //at least 3 numbers
            else if (!Regex.IsMatch(str, @"(?:.*\d){3,}")) return false;
            //at least 1 special character
            else if (!Regex.IsMatch(str, @"(?:.*[!@#$%^&*()\\[\]{}\-_+=~`|:;""'<>,./?]){1,}")) return false;
            //does not contain spaces
            else if (Regex.IsMatch(str, @"\s")) return false;

            //password good to go!
            else return true;
        }
    }
}