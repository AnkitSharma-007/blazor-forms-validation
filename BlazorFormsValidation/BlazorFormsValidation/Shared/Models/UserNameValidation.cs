using System.ComponentModel.DataAnnotations;

namespace BlazorFormsValidation.Shared.Models
{
    class UserNameValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!value.ToString().ToLower().Contains("admin"))
            {
                return null;
            }

            return new ValidationResult("The UserName can not contain the word admin.",
                new List<string> { validationContext.MemberName });
        }
    }
}
