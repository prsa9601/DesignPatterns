using Application.Notification.Fallback;
using Domain.Notification;
using Domain.Notification.Interfaces;
using MediatR;

namespace Application.Notification.Commans.TemplateMethod
{
    public class SendNotificationDesignPatternCommand : IRequest
    {
        public List<INotificationSender> Senders { get; set; } = new();
    }
    public class SendNotificationDesignPatternCommandHandler : IRequestHandler<SendNotificationDesignPatternCommand>
    {
        private readonly INotificationSender _sender;
        private readonly IFallbackNotificationSender _fallback;

        public SendNotificationDesignPatternCommandHandler(INotificationSender sender, IFallbackNotificationSender fallback)
        {
            _sender = sender;
            _fallback = fallback;
        }

        public Task<Unit> Handle(SendNotificationDesignPatternCommand request, CancellationToken cancellationToken)
        {
            NotificationMessage message = new NotificationMessage()
            {
                To = "parsa",
                Subject = "Message Sender",
                Body = "Message Is Send",
                IsUrgent = true,
            };

            foreach (var item in request.Senders)
            {
                _fallback.AddService(item);
            }
            _fallback.Send(message);
            return Task.FromResult(Unit.Value);
        }
    }
}
