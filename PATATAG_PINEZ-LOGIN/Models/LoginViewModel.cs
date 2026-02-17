using System.ComponentModel.DataAnnotations;

namespace PATATAG_PINEZ_LOGIN.Models
{
    // ViewModel used to capture and validate user input during login.
    public class LoginViewModel
    {
        // Required email field with built-in email format validation
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        // Required password field
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
