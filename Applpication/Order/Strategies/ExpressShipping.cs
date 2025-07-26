using Domain.Order.Services.StrategyDesign;

namespace Application.Order.Strategies
{
    public class ExpressShipping : IShippingStrategy
    {
        public decimal Calculate(Domain.Order.Order order)
        {
            return order.TotalPrice.RialValue * 10000;
        }
    }
}
