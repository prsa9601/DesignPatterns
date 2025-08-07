using Domain.Order;
using Domain.Order.Visitors;

namespace Application.Order.Visitors
{
    public class OrderTaxCalculate : IOrderVisitor
    {
        private decimal _totalTax;
        private const decimal TaxRate = 0.08m;
        public decimal Calculate(Domain.Order.Order order)
        {
            _totalTax = 0;
            order.Accept(this);
            return _totalTax;
        }
        public void Visit(Domain.Order.Order order) { }

        public void Visit(OrderItem orderItem)
        {
            _totalTax = orderItem.SingleProductPrice * orderItem.Quantity * TaxRate;
        }
    }
}
