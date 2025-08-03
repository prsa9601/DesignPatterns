using Domain.Proxy.Interfaces;

namespace Infrastructure.Proxy.Services
{
    public class InventoryService : IInventoryService
    {
        public int GetStock(Guid productId, int stockResult)
        {
            Console.WriteLine($"GetStock Is Running From Infrastructure Layer " +
                $"Your ProductId Is {productId}");
            return stockResult;
        }

        public void UpdateStock(Guid productId, int quantity)
        {
            Console.WriteLine($"Stock {productId} Is Being Updated.");
        }
    }
}
