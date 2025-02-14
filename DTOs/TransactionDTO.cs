namespace ABCMoneyTransfer.DTOs
{
    public class TransactionDTO
    {
        public PartyDTO Sender { get; set; }
        public PartyDTO Receiver { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal PayoutAmount { get; set; }

        public DateTime CreatedAt { get; set; }
        public string TransactionId { get; set; }
    }
}
