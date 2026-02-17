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
    public class LoginModel : PageModel
    {
        private readonly DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context _context;
        private readonly PasswordHasher<User> _hasher = new();

        public LoginModel(DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = _context.User.FirstOrDefault(u => u.Email == Input.Email);

            if (user == null)
            {
                ModelState.AddModelError("Input.Email", "No account found with this email");
                return Page();
            }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, Input.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("Input.Password", "Incorrect Password");
                return Page();
            }

            return RedirectToPage("/Privacy");
        }
    }
}
