namespace Domain.Order.Interfaces
{
    //ChainOfResponsibility
    public interface IOrderHandler
    {
        IOrderHandler SetNext(IOrderHandler orderHandler);
        Task HandleAsync(Order order);
    }
}
