using Domain.Order.Services.ObserverDesign;

namespace Domain.Order.Services.Factory
{
    //Factory Pattern
    public interface IOrderServiceFactory
    {
        IOrderObserver CreateEmailSender();
        IOrderObserver CreateInventoryService();
    }
}
