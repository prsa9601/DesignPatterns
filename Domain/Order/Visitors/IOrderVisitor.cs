namespace Domain.Order.Visitors
{
    public interface IOrderVisitor
    {
        void Visit(Order order);
        void Visit(OrderItem orderItem);
    }
}
