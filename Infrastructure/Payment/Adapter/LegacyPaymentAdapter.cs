using Application.Payment.Services;
using Infrastructure.Payment.LegacyPayment;

namespace Infrastructure.Payment.Adapter
{
    public class LegacyPaymentAdapter : IPaymentService
    {
        private readonly LegacyPaymentService _paymentService;

        public LegacyPaymentAdapter(LegacyPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void Pay()
        {
            _paymentService.PaymentProcess("MerchantId_123", 16087550000976);
            throw new NotImplementedException("The Pay Method Is Works");
        }
    }
}
