using Domain.Notification.Enum;
using Domain.Notification.Interfaces;
using Domain.Notification.Services;
using MediatR;

namespace Application.Notification.Commands.SendNotification
{
    //Dependency Inversion & Factory Method Design
    public class SendNotificationCommand : IRequest
    {
        public string message { get; set; }
        public NotificationType notificationType { get; set; }
    }

    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly INotificationServiceFactory _service;

        public SendNotificationCommandHandler(INotificationServiceFactory service)
        {
            _service = service;
        }

        //public Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        //{
    
        //}
        //بجای null به ما unit میده توی جنریک ها
        Task<Unit> IRequestHandler<SendNotificationCommand, Unit>.Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var service = _service.Create(request.notificationType);
            service.Send(request.message);
            //return Task.CompletedTask;
            return Task.FromResult(Unit.Value);
        }
    }

}
