using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BulbasaurAPI.DataAnnotations
{
    public class OnlyLetters : ValidationAttribute
    {
        // Checks a string for only a-z and A-Z + åäö and ÅÄÖ
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var strVal = (string)value;

            string pattern = "[a-zåäöA-ZÅÄÖ]+";

            var match = Regex.Match(strVal, pattern);

            return match.Success ?
                 ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}