using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.Models
{
    public class Receiver
    {
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
