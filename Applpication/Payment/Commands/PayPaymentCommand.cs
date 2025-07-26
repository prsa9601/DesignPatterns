using Application.Payment.Services;
using MediatR;

namespace Application.Payment.Commands
{
    public class PayPaymentCommand : IRequest
    {
    }

    internal class PayPaymentCommandHandler : IRequestHandler<PayPaymentCommand>
    {
        private readonly IPaymentService _paymentService;

        public PayPaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Task<Unit> Handle(PayPaymentCommand request, CancellationToken cancellationToken)
        {
            _paymentService.Pay();
            return Task.FromResult(Unit.Value);
        }
    }
}
