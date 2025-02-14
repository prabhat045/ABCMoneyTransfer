namespace ABCMoneyTransfer.Models
{
    public class PaymentDetail
    {
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal ExchangeRate { get; set; }

    }
}
