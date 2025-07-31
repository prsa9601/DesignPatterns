using Application.Order.Services;

namespace Design_Patterns_API.Facade
{
    public class OrderFacade
    {
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly ShippingService _shippingService;

        public OrderFacade(InventoryService inventoryService, 
            PaymentService paymentService, ShippingService shippingService)
        {
            _inventoryService = inventoryService;
            _paymentService = paymentService;
            _shippingService = shippingService;
        }
        public void PlaceOrder(string productId, int quantity, string accountId, decimal amount, string address)
        {
            var orderId = Guid.NewGuid().ToString();

            if (!_inventoryService.CheckStock(productId, quantity))
                throw new Exception("Out of stock");

            if (!_paymentService.ProcessPayment(accountId, amount))
                throw new Exception("Payment failed");

            _shippingService.ShipOrder(orderId, address);

            Console.WriteLine($"Order {orderId} placed successfully!");
        }

    }
}
