using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
