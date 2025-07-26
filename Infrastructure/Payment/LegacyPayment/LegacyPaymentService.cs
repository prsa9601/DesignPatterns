namespace Infrastructure.Payment.LegacyPayment
{
    //Adaptee Service
    //سرویس خارجی
    public class LegacyPaymentService
    {
        public LegacyPaymentService()
        {
            
        }
        public void PaymentProcess(string merchantId, decimal price)
        {
            throw new NotImplementedException("Payment Is Processing");
        }
    }
}
