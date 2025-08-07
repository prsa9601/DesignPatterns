using Application.Order.Visitors.Services;
using MediatR;

namespace Application.Order.Command.ProcessOrder
{
    public class ProcessOrderCommand : IRequest
    {
    }
    public class ProcessOrderCommandHandler : IRequestHandler<ProcessOrderCommand>
    {
        private readonly OrderProcessor _processor;

        public ProcessOrderCommandHandler(OrderProcessor processor)
        {
            _processor = processor;
        }

        public Task<Unit> Handle(ProcessOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Order.Order
            {
                Id = Guid.NewGuid(),
                Products = new Dictionary<Guid, int>() { { Guid.NewGuid(), 342 } },
                //Status = Domain.Order.OrderStatus.Confirmed,
                TotalPrice =new Domain.Order.Money(3541223),
                UserId = Guid.NewGuid(),
            };
            var result = _processor.ProcessOrder(order);
            return Task.FromResult(Unit.Value);
        }
    }
}
