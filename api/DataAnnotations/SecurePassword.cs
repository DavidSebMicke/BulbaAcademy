using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BulbasaurAPI.DataAnnotations
{
    public class SecurePassword : ValidationAttribute
    {
        // Checks for if the password is valid
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string strVal = (string)value;

            // Catches spaces
            var spacePattern = @"\s";

            var patterns = new string[] {
            "([a-zåäö]){3,}",   // 3 lower case letters
            "([A-ZÅÄÖ]){3,}",    // 3 upper case letters
            "([0-9]){3,}",      // 3 numbers
            "([!@#$%^&*()\\\\[\\]{}\\-_+=~`|:;\"'<>,./?]){1,}", // 1 special character
            };

            // Checks the patterns and checks for spaces
            var isValid = patterns.All(p => Regex.Match(strVal, p).Success) && !Regex.Match(strVal, spacePattern).Success;

            return isValid ?
                ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}