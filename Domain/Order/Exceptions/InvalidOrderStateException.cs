namespace Domain.Order.Exceptions
{
    public class InvalidOrderStateException : Exception
    {
        public InvalidOrderStateException(string message) : base(message) { }
        public InvalidOrderStateException(OrderStatus currentStatus, string action):
            base($"Cannot {action} order in {currentStatus} state") { }
    }
}
