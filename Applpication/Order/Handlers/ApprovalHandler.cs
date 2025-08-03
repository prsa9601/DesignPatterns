using Application.Order.Handlers.BaseHandler;

namespace Application.Order.Handlers
{
    public class ApprovalHandler : BaseOrderHandler
    {
        public override async Task HandleAsync(Domain.Order.Order order)
        {
            if (order.TotalPrice.RialValue < 5000000)
            {
                //order.IsApproved();
                Console.WriteLine("Order auto-approved");
            }
            await base.HandleAsync(order);
        }
    }
}
