using Application.Order.Services;
using MediatR;

namespace Application.Order.Command.Create
{
    public class CreateOrderCommand : IRequest
    {
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly OrderProcessingService _processingService;

        public CreateOrderCommandHandler(OrderProcessingService processingService)
        {
            _processingService = processingService;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _processingService.ProcessHandler(new Domain.Order.Order
            {
                TotalPrice = new Domain.Order.Money(200),
                UserId = Guid.NewGuid(),
                Products = new Dictionary<Guid, int>
                {
                    { Guid.NewGuid(),55},
                { Guid.NewGuid(),34}
                }
            });
            return await Task.FromResult(Unit.Value);
        }
    }
}
