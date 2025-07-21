using Domain.Order.Services.ObserverDesign;

namespace Application.Order.ObserverDesign
{
    public class OrderService
    {
        private readonly IEnumerable<IOrderObserver> _observers;

        public OrderService(IEnumerable<IOrderObserver> observers)
        {
            _observers = observers;
        }

        public void PlaceOrder(Domain.Order.Order order)
        {
            foreach (var observer in _observers)
            {
                observer.OnOrderPlaced(order);
            }
        }
    }
}
