using Domain.Proxy.Interfaces;
using MediatR;

namespace Application.Proxy.Commands
{
    public class UpdateInventoryCommand : IRequest
    {
        public Guid productId { get; set; } = Guid.NewGuid();
        public int quantity { get; set; }
    }
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand>
    {
        private readonly IInventoryService inventoryService;

        public UpdateInventoryCommandHandler(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        public Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            inventoryService.GetStock(request.productId, request.quantity);
            inventoryService.UpdateStock(request.productId, request.quantity);
            return Task.FromResult(Unit.Value);
        }
    }
}
