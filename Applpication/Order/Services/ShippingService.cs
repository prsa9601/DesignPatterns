namespace Application.Order.Services
{
    public class ShippingService
    {
        public void ShipOrder(string orderId, string address)
        {
            // منطق ارسال سفارش
            Console.WriteLine($"Shipping order {orderId} to {address}");
        }
    }
}
