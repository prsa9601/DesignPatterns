using Domain.Proxy.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Proxy.Services
{
    public class InventoryServiceProxy : IInventoryService
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger _logger;

        public InventoryServiceProxy(IInventoryService inventoryService, ILogger logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        public int GetStock(Guid productId, int stockResult)
        {
            _logger.LogInformation("اینجا تو پروکسی هر کاری میتونم بکنمحتی میتونم جلوی ادامه پروسه " +
                "رو بگیرم یا هزاران موضوع رو چک کنم!");
            _inventoryService.GetStock(productId, stockResult);
            return stockResult;
        }

        public void UpdateStock(Guid productId, int quantity)
        {
            _logger.LogInformation("اینجا تو پروکسی هر کاری میتونم بکنمحتی میتونم جلوی ادامه پروسه " +
                "رو بگیرم یا هزاران موضوع رو چک کنم!");

            _inventoryService.UpdateStock(productId, quantity);
        }
    }
}
