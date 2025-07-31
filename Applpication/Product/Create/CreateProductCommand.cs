using Domain.Product;
using Domain.Product.Strategies;
using Domain.Product.ValueObjects;
using MediatR;

namespace Application.Product.Create
{
    public class CreateProductCommand : IRequest
    {
        public string name { get; set; } = "Default Product Name";
        public Money money { get; set; } = new Money(1135891273,"IRR");
        public WeightStrategy weightStrategy { get; set; } = new WeightStrategy();
        public CountableStrategy countableStrategy { get; set; } = new CountableStrategy();
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product1 = new Domain.Product.Product
                (request.name, request.money,request.countableStrategy);

            var product2 = new Domain.Product.Product
                (request.name, request.money,request.weightStrategy);
            return Task.FromResult(Unit.Value);
        }
    }
}
