using Domain.Order;
using Domain.Product.Visitors;

namespace Application.Product.Visitors
{
    public class ProductDiscountVisitor : IProductVisitor
    {
        private decimal _discountRate;
        //public ProductDiscountVisitor(decimal discountRate) =>
        //    _discountRate = discountRate;
        public void SetDiscount(decimal discountRate) =>
            _discountRate = discountRate;
        public void ApplyDiscount(Domain.Product.Product product)
        {
            product.Accept(this);
        }
        public void Visit(Domain.Product.Product product)
        {
            product.UpdatePrice(product.Price.Amount * (1 - _discountRate));
        }
    }
}
