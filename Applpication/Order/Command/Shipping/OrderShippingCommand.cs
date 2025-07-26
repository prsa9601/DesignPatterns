using Application.Order.Strategies;
using Domain.Order.Services.StrategyDesign;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Command.Shipping
{
    internal class OrderShippingCommand : IRequest
    {
    }
    internal class OrderShippingCommandHandler : IRequestHandler<OrderShippingCommand>
    {
        private readonly IShippingStrategy _strategy;

        public OrderShippingCommandHandler(IShippingStrategy strategy)
        {
            _strategy = strategy;
        }

        Task<Unit> IRequestHandler<OrderShippingCommand, Unit>.Handle(OrderShippingCommand request, CancellationToken cancellationToken)
        {
            //_strategy.Calculate(new StandardShipping());
            //return Task.CompletedTask;
            return null;
        }
    }
}
