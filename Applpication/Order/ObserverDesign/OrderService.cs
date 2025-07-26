using Domain.Order.Services.ObserverDesign;

namespace Application.Order.ObserverDesign
{
    public class OrderService
    {
        private List<IOrderObserver> _observers = new();

        //public OrderService(IOrderObserver observers)
        //{
        //    _observers = observers;
        //}

        public void Subscribe(IOrderObserver observer)
        {
            _observers.Add(observer);
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
