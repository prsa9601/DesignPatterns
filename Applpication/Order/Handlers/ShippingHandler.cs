using Application.Order.Handlers.BaseHandler;
using System.Runtime.CompilerServices;

namespace Application.Order.Handlers
{
    public class ShippingHandler : BaseOrderHandler
    {
        public override async Task HandleAsync(Domain.Order.Order order)
        {
            if (order.TotalPrice.RialValue>1000)
            {
                Console.WriteLine("Free shipping applied");
            }
            await base.HandleAsync(order);
        }
    }
}
