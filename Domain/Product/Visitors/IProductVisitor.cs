namespace Domain.Product.Visitors
{
    public interface IProductVisitor
    {
        void Visit(Product product);
    }
}
