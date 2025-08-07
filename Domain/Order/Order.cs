using Domain.Order.States;
using Domain.Order.Visitors;

namespace Domain.Order
{
    public class Order
    {
        public Guid Id { get; set; }
        public Dictionary<Guid, int>? Products { get; set; }//id, number
        public Guid UserId { get; set; }
        public Money TotalPrice { get; set; }
        private bool IsFinally { get; set; } = false;
        public OrderStatus Status { get; private set; } = OrderStatus.Draft;

        private IOrderState? _state;
        //public Order(Guid userId, Dictionary<Guid, int> products)
        //{
        //    userId == null ? throw new ArgumentNullException() : UserId = userId;
        //    Products = products;
        //}
        public Order()
        {

        }
        //Visitor Pattern
        public void Accept(IOrderVisitor visitor) => visitor.Visit(this);

        public void SetState(IOrderState state)
        {
            _state = state;
        }
        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
        }

        //public void Process(Order order) => _state.Process(this);
        public void Confirm()
        {
            if (_state is null)
                throw new InvalidOperationException("State not initialized");

            _state.Confirm(this);
        }

        public void Process()
        {
            if (_state is null)
                throw new InvalidOperationException("State not initialized");

            _state.Process(this);
        }

        public void Ship()
        {
            if (_state is null)
                throw new InvalidOperationException("State not initialized");

            _state.Ship(this);
        }

        public void Cancel()
        {
            if (_state is null)
                throw new InvalidOperationException("State not initialized");

            _state.Cancel(this);
        }

        public void Finally()
        {
            IsFinally = true;
        }
    }
}
