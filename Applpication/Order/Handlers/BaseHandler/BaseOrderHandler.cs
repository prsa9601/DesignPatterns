using Domain.Order.Interfaces;

namespace Application.Order.Handlers.BaseHandler
{
    public abstract class BaseOrderHandler : IOrderHandler
    {
        private IOrderHandler _nextHandler;

        public virtual async Task HandleAsync(Domain.Order.Order order)
        {
            if (_nextHandler != null)
            {
                await _nextHandler.HandleAsync(order);
            }
        }

        public IOrderHandler SetNext(IOrderHandler orderHandler)
        {
            _nextHandler = orderHandler;
            return orderHandler ;
        }
    }
}
