using Domain.Order.Services.StrategyDesign;

namespace Application.Order.Strategies
{
    public class StandardShipping : IShippingStrategy
    {
        public decimal Calculate(Domain.Order.Order order)
        {
            return order.TotalPrice.RialValue * 80;
        }
    }
}
