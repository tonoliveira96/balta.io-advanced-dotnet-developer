using PaymenContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;


namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transacrionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email) :
            base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
        {
            TransacrionCode = transacrionCode;
        }

        public string TransacrionCode { get; private set; }
    }
}
