using Application.Order.Handlers.BaseHandler;

namespace Application.Order.Handlers
{
    public class ValidationHandler : BaseOrderHandler
    {
        public override Task HandleAsync(Domain.Order.Order order)
        {
            if (order.Products.Count() <= 0)
            {
                throw new ArgumentException("The Product Count Can Not Be null");
            }
            if (order.TotalPrice.RialValue <= 0)
            {
                throw new ArgumentException("The TotalPrice Cant Be null");
            }
            return base.HandleAsync(order);
        }
    }
}
