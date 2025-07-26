using Application.Order.ObserverDesign;
using Domain.Order.Services.Builder;
using Domain.Order.Services.Factory;
using MediatR;

namespace Application.Order.Command.Finally
{
    public class FinallyOrderCommand : IRequest
    {
    }

    internal class FinallyOrderCommandHandler : IRequestHandler<FinallyOrderCommand>
    {
        private readonly IOrderBuilder _builder;
        private readonly OrderService _service;
        private readonly IOrderServiceFactory _factory;
        public FinallyOrderCommandHandler(IOrderBuilder builder, OrderService service, IOrderServiceFactory factory)
        {
            _builder = builder;
            _service = service;
            _factory = factory;
        }

        //public Task Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
        //{

        //    return Task.CompletedTask;
        //}

        Task<Unit> IRequestHandler<FinallyOrderCommand, Unit>.Handle(FinallyOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _builder.WithUserId(new Guid()).WithProducts(new Dictionary<Guid, int>
            {
                //[Guid.Parse("hg56")] = 2,
                //[Guid.Parse("hjkgtyety7-jhgkg-kjgeigfyuqw397u")] = 3,
                [new Guid()] = 2,
                [new Guid()] = 3,
            }).Build();

            //ساخت اینترفیس براشون
            _service.Subscribe(_factory.CreateEmailSender());
            _service.Subscribe(_factory.CreateInventoryService());
            _service.PlaceOrder(order);
            return null;
        }
    }
}
