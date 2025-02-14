using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.DTOs
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }
        
        [Required]
        public string LastName { get; set; }
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; } 


    }
}
