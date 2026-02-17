using System.ComponentModel.DataAnnotations;

namespace PATATAG_PINEZ_LOGIN.Models
{
    // Represents the User table in the database.
    public class User
    {
        // Primary Key (auto-incremented by the database)
        [Key]
        public int Id { get; set; }

        // User's full name (required, max 100 characters)
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        // User's email address (required, must be valid format)
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Stores the hashed password (never store plain text passwords)
        [Required]
        public string PasswordHash { get; set; }
    }
}