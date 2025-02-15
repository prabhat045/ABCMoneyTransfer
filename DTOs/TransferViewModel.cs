using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.DTOs
{
    public class TransferViewModel
    {
        [Required]
        public string ReceiverFirstName { get; set; }
        public string? ReceiverMiddleName { get; set; }
        [Required]
        public string ReceiverLastName { get; set; }
        [Required]
        public string ReceiverAddress { get; set; }
        [Required]
        public string ReceiverCountry { get; set; }

        [Required]
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        [Range(100.01, double.MaxValue, ErrorMessage = "Transfer amount must be greater than 100.")]
        public decimal TransferAmountMYR { get; set; }
        public decimal ExchangeRate { get; set; } 
        public decimal PayoutAmount => TransferAmountMYR * ExchangeRate;
    }
}
