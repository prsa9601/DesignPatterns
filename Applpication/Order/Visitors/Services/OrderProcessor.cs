namespace Application.Order.Visitors.Services
{
    public class OrderProcessor
    {
        private readonly OrderTaxCalculate _orderTaxCalculate;
        private readonly OrderReportGenerator _orderReportGenerator;

        public OrderProcessor(OrderReportGenerator orderReportGenerator, OrderTaxCalculate orderTaxCalculate)
        {
            _orderReportGenerator = orderReportGenerator;
            _orderTaxCalculate = orderTaxCalculate;
        }
        public (decimal Tax, string report) ProcessOrder(Domain.Order.Order order)
        {
            decimal tax = _orderTaxCalculate.Calculate(order);
            string report = _orderReportGenerator.Generate(order);

            return (tax, report);   
        }
    }
}
