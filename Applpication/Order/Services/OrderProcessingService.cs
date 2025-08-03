using Application.Order.Handlers.BaseHandler;
using Domain.Order;
using Domain.Order.Interfaces;

namespace Application.Order.Services
{
    public class OrderProcessingService
    {
        private readonly IOrderHandler _orderHandler;

        public OrderProcessingService(IOrderHandler orderHandler)
        {
            this._orderHandler = orderHandler;
        }
        public async Task ProcessHandler(Domain.Order.Order order)
        {
            await _orderHandler.HandleAsync(order);
        }
    }
}
