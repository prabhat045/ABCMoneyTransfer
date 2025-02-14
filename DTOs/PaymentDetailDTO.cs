using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.DTOs
{
    public class PaymentDetailDTO
    {
        [Required]
        public string BankName { get; set; }
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TransferAmount { get; set; }

        [Required]
        public decimal ExchangeRate { get; set; }

        public PaymentDetailDTO()
        {

        }

        public PaymentDetailDTO(TransferViewModel transferViewModel)
        {
            BankName = transferViewModel.BankName;
            AccountNumber = transferViewModel.AccountNumber;
            ExchangeRate = transferViewModel.ExchangeRate;
            TransferAmount = transferViewModel.TransferAmountMYR;
        }

    }
}
