using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BulbasaurAPI.DataAnnotations
{
    public class OnlyNumbers : ValidationAttribute
    {
        // Checks an incoming string if it contains only numbers
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string strVal = (string)value;

            string pattern = "^[0-9]+";

            var match = Regex.Match(strVal, pattern);

            return match.Success ?
                ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}