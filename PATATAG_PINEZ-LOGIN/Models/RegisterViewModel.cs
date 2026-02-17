using System.ComponentModel.DataAnnotations;

namespace PATATAG_PINEZ_LOGIN.Models
{
    // ViewModel used to capture and validate user input during registration.
    public class RegisterViewModel
    {
        // Full name is required and must contain only letters and spaces
        [Required(ErrorMessage = "Full name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full name can only contain letters and spaces")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        // Required email field with email format validation
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        // Required password field with minimum length rule
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Confirms the password by comparing it to the Password property
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        // Forces the checkbox to be checked before registration is allowed
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the Terms & Conditions")]
        [Display(Name = "I agree to the Terms & Conditions")]
        public bool AgreeToTerms { get; set; }
    }
}