using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BulbasaurAPI.DataAnnotations
{
    public class PhoneNumber : ValidationAttribute
    {
        // Checks if the phonenumber is valid (removes - and spaces before testing).
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string strVal = (string)value;

            strVal.Replace('-', string.Empty.ToCharArray()[0]);
            strVal.Replace(' ', string.Empty.ToCharArray()[0]);

            string pattern = @"(0|\+)[0-9]+";

            var match = Regex.Match(strVal, pattern);

            return match.Success ?
                ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}