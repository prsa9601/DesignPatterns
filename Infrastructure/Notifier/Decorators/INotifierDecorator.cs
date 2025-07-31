using Application.Decorator.Interfaces;

namespace Infrastructure.Notifier.Decorators
{
    public abstract class INotifierDecorator : INotifier
    {
        protected readonly INotifier _notifier;

        public INotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier?.Send(message);
        }
    }
}
