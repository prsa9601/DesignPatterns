using Application.Decorator.Interfaces;
using MediatR;

namespace Application.Notifier.Commands
{
    public class SendNotificationCommand : IRequest
    {
    }

    internal class SendNotificaitonCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly INotifier _notifier;
        //private readonly LoggingDecorator

        public SendNotificaitonCommandHandler(INotifier notifier)
        {
            _notifier = notifier;
        }

        public Task<Unit> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            _notifier.Send("Email Is Send From Application Layer.");
            return Task.FromResult(Unit.Value);
        }
    }
}
