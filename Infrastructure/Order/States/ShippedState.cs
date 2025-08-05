using Domain.Order;
using Domain.Order.Exceptions;
using Domain.Order.States;

namespace Infrastructure.Order.States
{
    public class ShippedState : IOrderState
    {
        public OrderStatus Status => OrderStatus.Shipped;

        public void Confirm(Domain.Order.Order order)
        {
            order.UpdateStatus(OrderStatus.Confirmed);
        }

        public void Process(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Cannot process order in pending state");
        }

        public void Ship(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Cannot ship order in pending state");
        }

        public void Cancel(Domain.Order.Order order)
        {
            order.UpdateStatus(OrderStatus.Cancelled);
        }
    }
}
