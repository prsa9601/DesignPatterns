using Domain.Order;
using Domain.Order.Exceptions;
using Domain.Order.States;

namespace Infrastructure.Order.States
{
    public class ProcessingState : IOrderState
    {
        public OrderStatus Status => OrderStatus.Processing;

        public void Confirm(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Order is already confirmed");
        }

        public void Process(Domain.Order.Order order)
        {
            throw new InvalidOrderStateException("Order is already processing");
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
