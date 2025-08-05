using Application.Order.States.Interfaces;
using Domain.Order.Services.Factory;
using MediatR;

namespace Application.Order.Command.ChangeStatus
{
    public class ChangeOrderStatusCommand : IRequest
    {
    }
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand>
    {
        private readonly IOrderStateFactory _factory;

        public ChangeOrderStatusCommandHandler(IOrderStateFactory factory)
        {
            _factory = factory;
        }

        public Task<Unit> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = new Domain.Order.Order
            {
                Products = new Dictionary<Guid, int>()
                {
                    { Guid.NewGuid(),5234},
                    { Guid.NewGuid(), 745234 }
                },
                TotalPrice = new Domain.Order.Money(4653),
                UserId = Guid.NewGuid(),
            };
            var pendingOrderState = _factory.CreateState(Domain.Order.OrderStatus.Pending);
            //var processingOrderState = _factory.CreateState(Domain.Order.OrderStatus.Processing);
            //var shippedOrderState = _factory.CreateState(Domain.Order.OrderStatus.Shipped);
            //var cancelledOrderState = _factory.CreateState(Domain.Order.OrderStatus.Cancelled);

            order.SetState(pendingOrderState);
            order.Cancel();

            return Task.FromResult(Unit.Value);
        }
    }
}
