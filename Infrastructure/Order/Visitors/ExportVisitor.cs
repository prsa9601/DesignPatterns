using Domain.Order;
using Domain.Order.Visitors;

namespace Infrastructure.Order.Visitors
{
    public class ExportVisitor : IOrderVisitor
    {
        private readonly string _filePath;

        public ExportVisitor(string filePath)
        {
            _filePath = filePath;
        }
        public void Export(Domain.Order.Order order)
        {
            File.WriteAllText(_filePath, "");
            order.Accept(this);
        }

        public void Visit(Domain.Order.Order order)
        {
            File.AppendAllText(_filePath, $"ORDER_EXPORT|{order.Id}|{DateTime.UtcNow}\n");
        }

        public void Visit(OrderItem orderItem)
        {
            File.AppendAllText(_filePath,
              $"ITEM|{orderItem.Id}|{orderItem.Quantity}|{orderItem.SingleProductPrice}\n");
        }
    }
}
