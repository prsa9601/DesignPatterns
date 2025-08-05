using Domain.Order;
using Domain.Order.Exceptions;
using Domain.Order.States;

namespace Infrastructure.Order.States
{
    public class PendingState : IOrderState
    {
        public OrderStatus Status => OrderStatus.Pending;

        public void Cancel(Domain.Order.Order order)
        {
            order.UpdateStatus(OrderStatus.Cancelled);
        }

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
    }
}
