namespace ABCMoneyTransfer.DTOs
{
    public class TransferViewModel
    {
        public string ReceiverFirstName { get; set; }
        public string? ReceiverMiddleName { get; set; } 
        public string ReceiverLastName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCountry { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }

       
        public decimal TransferAmountMYR { get; set; }
        public decimal ExchangeRate { get; set; } 
        public decimal PayoutAmount => TransferAmountMYR * ExchangeRate;
    }
}
