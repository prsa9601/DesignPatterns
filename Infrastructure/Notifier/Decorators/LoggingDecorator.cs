using Application.Decorator.Interfaces;

namespace Infrastructure.Notifier.Decorators
{
    public class LoggingDecorator : INotifierDecorator
    {
        public LoggingDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            Console.WriteLine($"Log: {DateTime.UtcNow} - {message}");
            base.Send(message);
        }
    }
}
