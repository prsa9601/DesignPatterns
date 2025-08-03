using Application.Order.Handlers.BaseHandler;
using Domain.Order;

namespace Application.Order.Handlers
{
    public class DiscountHandler : BaseOrderHandler
    {
        public override async Task HandleAsync(Domain.Order.Order order)
        {
            if (order.Products.Count() > 10)
            {
                 Money.ApplyDiscount(order.TotalPrice.RialValue, 10);
            }
            await base.HandleAsync(order);
        }
    }
}
