using Domain.Order;
using Domain.Order.Exceptions;
using Domain.Order.States;

namespace Infrastructure.Order.States
{
    public class CancelledState : IOrderState
    {
        public OrderStatus Status => OrderStatus.Cancelled;

        public void Confirm(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Cannot confirm cancelled order");
        }

        public void Process(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Cannot process cancelled order");
        }

        public void Ship(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Cannot ship cancelled order");
        }

        public void Cancel(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Order is already cancelled");
        }
    }
}
