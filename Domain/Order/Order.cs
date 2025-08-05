using Domain.Order.States;

namespace Domain.Order
{
    public class Order
    {
        private Guid Id { get; set; }
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
    public enum OrderStatus
    {
        Draft,
        Pending,       // در انتظار پرداخت
        Processing,    // در حال پردازش
        Shipped,       // ارسال شده
        Confirmed,     // تکمیل شده
        //Completed,     // تکمیل شده
        //OnHold,        // در حال آماده‌سازی
        Cancelled      // لغو شده
    }
    //public static IOrderState CreateStateFromStatus(OrderStatus orderStatus)
    //{
    //    return orderStatus switch
    //    {
    //        OrderStatus.Pending => OrderStatus.Pending,
    //        //OrderStatus.Processing =>new Process,
    //        OrderStatus.Shipped =>,
    //        OrderStatus.Completed =>,
    //        //OrderStatus.OnHold=>,
    //        OrderStatus.Cancelled =>,
    //        _ => throw new ArgumentOutOfRangeException(),

    //    };
    //}
}
