using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PATATAG_PINEZ_LOGIN.Data;
using PATATAG_PINEZ_LOGIN.Models;

namespace PATATAG_PINEZ_LOGIN.Pages.Users
{
    // Handles the Login page logic (GET + POST).
    public class LoginModel : PageModel
    {
        // Database context used to access the User table
        private readonly PATATAG_PINEZ_LOGINContext _context;

        // Password hasher used to verify the entered password against the stored hash
        private readonly PasswordHasher<User> _hasher = new();

        public LoginModel(PATATAG_PINEZ_LOGINContext context)
        {
            _context = context;
        }

        // Loads the login page
        public IActionResult OnGet()
        {
            return Page();
        }

        // Holds the form input (Email + Password)
        [BindProperty]
        public LoginViewModel Input { get; set; }

        // Handles the login form submission
        public IActionResult OnPost()
        {
            // Stop if validation fails (required fields, email format, etc.)
            if (!ModelState.IsValid)
                return Page();

            // Find user by email
            var user = _context.User.FirstOrDefault(u => u.Email == Input.Email);

            // If no user exists, show an error message
            if (user == null)
            {
                ModelState.AddModelError("Input.Email", "No account found with this email");
                return Page();
            }

            // Verify the password by comparing input to stored hash
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, Input.Password);

            // If password is wrong, show an error message
            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("Input.Password", "Incorrect Password");
                return Page();
            }

            // If login is successful, redirect to another page
            return RedirectToPage("/Privacy");
        }
    }
}