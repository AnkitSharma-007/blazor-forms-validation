using System.ComponentModel.DataAnnotations;

namespace BlazorFormsValidation.Shared.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [UserNameValidation]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$",
            ErrorMessage = "Password should have minimum 8 characters, at least 1 uppercase letter, 1 lowercase letter and 1 number.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirm password fields do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Gender { get; set; }

        public Employee()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Gender = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Username = string.Empty;
        }
    }
}
