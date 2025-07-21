using Domain.Order.Services.ObserverDesign;

namespace Infrastructure.Order.Services
{
    public class InventoryService : IOrderObserver
    {
        public void OnOrderPlaced(Domain.Order.Order order)
        {
            throw new NotImplementedException();
        }
    }
}
