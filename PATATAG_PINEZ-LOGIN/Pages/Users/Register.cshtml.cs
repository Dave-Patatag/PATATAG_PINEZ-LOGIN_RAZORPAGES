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
    public class RegisterModel : PageModel
    {
        private readonly DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context _context;
        private readonly PasswordHasher<User> _hasher = new();

        public RegisterModel(DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (_context.User.Any(u => u.Email == Input.Email))
            {
                ModelState.AddModelError("Input.Email", "Email already registered");
                return Page();
            }

            var user = new User
            {
                FullName = Input.FullName,
                Email = Input.Email,
                PasswordHash = _hasher.HashPassword(null, Input.Password)
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return RedirectToPage("/Users/Login");
        }
    }
}
