namespace Domain.Order.States
{
    public interface IOrderState 
    {
        OrderStatus Status { get; }
        void Ship(Order order);
        void Confirm(Order order);
        void Process(Order order);
        //void Hold(Order order);
        void Cancel(Order order);
    }
}
