namespace Domain.Order.Services.ObserverDesign
{
    public interface IOrderObserver
    {
        public void OnOrderPlaced(Order order);
    }
}
