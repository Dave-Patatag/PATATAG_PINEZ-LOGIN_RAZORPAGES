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
    // Handles the Register page logic (POST).
    public class RegisterModel : PageModel
    {
        // Database context used to access and update the User table
        private readonly PATATAG_PINEZ_LOGINContext _context;

        // Password hasher used to store password securely as a hash
        private readonly PasswordHasher<User> _hasher = new();

        public RegisterModel(PATATAG_PINEZ_LOGINContext context)
        {
            _context = context;
        }

        // Holds the form input (FullName, Email, Password, ConfirmPassword, Terms)
        [BindProperty]
        public RegisterViewModel Input { get; set; }

        // Handles the register form submission
        public IActionResult OnPost()
        {
            // Stop if validation fails (required fields, password length, confirm match, terms, etc.)
            if (!ModelState.IsValid)
                return Page();

            // Prevent duplicate accounts using the same email
            if (_context.User.Any(u => u.Email == Input.Email))
            {
                ModelState.AddModelError("Input.Email", "Email already registered");
                return Page();
            }

            // Create a new User record using validated form input
            var user = new User
            {
                FullName = Input.FullName,
                Email = Input.Email,

                // Hash the password (never store plain text)
                PasswordHash = _hasher.HashPassword(null, Input.Password)
            };

            // Save the new user into the database
            _context.User.Add(user);
            _context.SaveChanges();

            // After successful registration, redirect to Login page
            return RedirectToPage("/Users/Login");
        }
    }
}