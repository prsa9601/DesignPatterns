using Application.Order.States.Interfaces;
using Domain.Order;
using Domain.Order.States;
using Infrastructure.Order.States;

namespace Infrastructure.Order.Services
{
    public class OrderStateFactory : IOrderStateFactory
    {
        public IOrderState CreateState(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => new PendingState(),
                OrderStatus.Confirmed => new ConfirmedState(),
                OrderStatus.Shipped => new ShippedState(),
                OrderStatus.Cancelled => new CancelledState(),
                OrderStatus.Processing => new ProcessingState(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
