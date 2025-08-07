using Domain.Order.Visitors;
using System.Text;

namespace Application.Order.Visitors
{
    public class OrderReportGenerator : IOrderVisitor
    {
        private readonly StringBuilder _report = new();
        public string Generate(Domain.Order.Order order)
        {
            _report.Clear();
            order.Accept(this);
            return _report.ToString();
        }
        public void Visit(Domain.Order.Order order)
        {
            _report.AppendLine($"Order Report - ID: {order.Id}");
            _report.AppendLine("-----------------------------------");
        }

        public void Visit(Domain.Order.OrderItem orderItem)
        {
            _report.AppendLine($"{orderItem.SingleProductPrice * orderItem.Quantity:C}");
        }
    }
}