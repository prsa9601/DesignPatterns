using Domain.Order;
using Domain.Order.Services.Builder;

namespace Application.Order.Builder
{
    public class OrderBuilder : IOrderBuilder
    {
        private Guid _userId;
        private Dictionary<Guid, int> _products;
        private Money _totalPrice;
        public Domain.Order.Order Build()
        {
            return new Domain.Order.Order()
            {
                UserId = _userId,
                Products = _products,
                TotalPrice = _totalPrice
            };
        }

        public IOrderBuilder WithProducts(Dictionary<Guid, int> products)
        {
            _products = products;
            return this;
        }

        public IOrderBuilder WithTotalPrice(long totalPrice)
        {
            _totalPrice = new Money(totalPrice);
            return this;
        }

        public IOrderBuilder WithUserId(Guid userId)
        {
            _userId = userId;
            return this;
        }
    }
}
