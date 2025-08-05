using Domain.Order;
using Domain.Order.States;

namespace Application.Order.States.Interfaces
{
    public interface IOrderStateFactory
    {
        IOrderState CreateState(OrderStatus status);
    }
}
