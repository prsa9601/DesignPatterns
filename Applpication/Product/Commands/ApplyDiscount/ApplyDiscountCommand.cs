using Application.Product.Visitors;
using Domain.Product.Strategies;
using MediatR;

namespace Application.Product.Commands.ApplyDiscount
{
    public class ApplyDiscountCommand : IRequest
    {
    }
    public class ApplyDiscountCommandHandler : IRequestHandler<ApplyDiscountCommand>
    {
        private readonly ProductDiscountVisitor _visitor;

        public ApplyDiscountCommandHandler(ProductDiscountVisitor visitor)
        {
            _visitor = visitor;
            _visitor.SetDiscount(.6m);
        }

        public Task<Unit> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
        {
            var countableStrategy = new CountableStrategy();
            _visitor.ApplyDiscount(new Domain.Product.Product(
                "default Name",  new Domain.Product.ValueObjects.Money(23532, "IR"),
                 countableStrategy
            ));
            return Task.FromResult(Unit.Value);
        }
    }
}
