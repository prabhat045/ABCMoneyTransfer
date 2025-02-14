using System.ComponentModel.DataAnnotations;

namespace ABCMoneyTransfer.DTOs
{
    public class TransferRequestDTO
    {
        [Required]
        public PartyDTO Receiver { get; set; }
        [Required]
        public PaymentDetailDTO PaymentDetail { get; set; }

        public TransferRequestDTO()
        {

        }

        public TransferRequestDTO(PartyDTO receiver, PaymentDetailDTO paymentDetail)
        {
            Receiver = receiver;
            PaymentDetail = paymentDetail;
        }


    }
}
