using Domain.Order;
using Domain.Order.Exceptions;

namespace Infrastructure.Order.States
{
    public class ConfirmedState : Domain.Order.States.IOrderState
    {
        public OrderStatus Status => OrderStatus.Confirmed;

        public void Confirm(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Order is already confirmed");
        }

        public void Process(Domain.Order.Order order)
        {
            order.UpdateStatus(OrderStatus.Pending);
        }

        public void Ship(Domain.Order.Order order)
        {
            order.UpdateStatus(OrderStatus.Shipped);
        }

        public void Cancel(Domain.Order.Order order)
        {
            order.UpdateStatus(OrderStatus.Cancelled);
        }
    }
}
