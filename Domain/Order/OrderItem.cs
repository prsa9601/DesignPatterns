using Domain.Order.Visitors;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Order
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; }
        public decimal SingleProductPrice { get; set; }
        public int Quantity { get; }

        public OrderItem(Guid productId, decimal singleProductPrice, int quantity)
        {
            ProductId = productId;
            SingleProductPrice = singleProductPrice;    
            Quantity = quantity;
        }

        public void Accept(IOrderVisitor visitor) => visitor.Visit(this);
    }
}
