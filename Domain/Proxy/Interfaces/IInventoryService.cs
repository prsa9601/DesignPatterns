namespace Domain.Proxy.Interfaces
{
    public interface IInventoryService
    {
        void UpdateStock(Guid productId, int quantity);
        int GetStock(Guid productId, int stockResult);
    }
}
