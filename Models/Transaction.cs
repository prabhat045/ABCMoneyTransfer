using System.Reflection;

namespace ABCMoneyTransfer.Models
{
    public class Transaction : BaseEntity
    {
        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }
        public PaymentDetail PaymentDetail { get; set; }

        public decimal PayoutAmount { get; private set; }

        public string senderUserId { get; set; }



        public Transaction() { }

        public Transaction(Sender sender, Receiver receiver, PaymentDetail paymentDetail,string senderId)
        {
            Sender = sender;
            Receiver = receiver;
            PaymentDetail = paymentDetail;
            senderUserId = senderId;
        }
    }
}
