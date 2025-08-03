using Domain.Proxy.Interfaces;

namespace Application.Proxy.Services
{
    public class InventoryManager
    {
        private readonly IInventoryService _inventoryService;

        public InventoryManager(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        public void AddStock(Guid productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException
                    ("تعداد اضافه کردن موجودی نمیتواند کمتر از یک باشد!");

            int currentStock = _inventoryService.GetStock(productId, quantity);
            _inventoryService.UpdateStock(productId, currentStock + quantity);
        }
    }
}
