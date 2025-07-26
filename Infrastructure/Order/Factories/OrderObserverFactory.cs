using Domain.Order.Services.Factory;
using Domain.Order.Services.ObserverDesign;
using Infrastructure.Order.Services;

namespace Infrastructure.Order.Factories
{
    public class OrderObserverFactory : IOrderServiceFactory
    {
        public IOrderObserver CreateEmailSender() => new EmailSender();

        public IOrderObserver CreateInventoryService() => new InventoryService();
    }
}
