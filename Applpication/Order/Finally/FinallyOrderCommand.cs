using Application.Order.ObserverDesign;
using Domain.Order.Services.Builder;
using Infrastructure.Order.Services;
using MediatR;

namespace Application.Order.Finally
{
    public class FinallyOrderCommand : IRequest
    {
    }

    internal class FinallyOrderCommandHandler : IRequestHandler<FinallyOrderCommand>
    {
        private readonly IOrderBuilder _builder;
        private readonly OrderService _service;
        public FinallyOrderCommandHandler(IOrderBuilder builder, OrderService service)
        {
            _builder = builder;
            _service = service;
        }

        public Task Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _builder.WithUserId(Guid.Parse("8935726jkdhuqioy80375")).WithProducts(new Dictionary<Guid, int>
            {
                [Guid.Parse("hg56")] = 2 ,
                [Guid.Parse("hjkgtyety7-jhgkg-kjgeigfyuqw397u")] = 3 ,
            }).Build();

            //_service.Subscribe(new EmailSender());
            //_service.Subscribe(new InventoryService());
            _service.PlaceOrder(order);
            return Task.CompletedTask;
        }
    }
}
