using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.DTOs
{
    public class PartyDTO
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

        public PartyDTO()
        {

        }
        public PartyDTO(TransferViewModel transferViewModel)
        {
            FirstName = transferViewModel.ReceiverFirstName;
            MiddleName = transferViewModel.ReceiverMiddleName;
            LastName = transferViewModel.ReceiverLastName;
            Address = transferViewModel.ReceiverAddress ; 
            Country = transferViewModel.ReceiverCountry;
        }
    }
}
