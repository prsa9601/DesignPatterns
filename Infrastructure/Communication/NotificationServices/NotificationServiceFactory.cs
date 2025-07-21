using Domain.Notification.Enum;
using Domain.Notification.Interfaces;
using Domain.Notification.Services;

namespace Infrastructure.Communication.NotificationServices
{
    //Dependency Inversion & Factory Design
    public class NotificationServiceFactory : INotificationServiceFactory
    {
        private readonly IEmailNotificationService _emailNotificationService;
        private readonly ISmsNotificationService _smsNotificationService;

        public NotificationServiceFactory(ISmsNotificationService smsNotificationService, IEmailNotificationService emailNotificationService)
        {
            _smsNotificationService = smsNotificationService;
            _emailNotificationService = emailNotificationService;
        }

        public INotificationService Create(NotificationType notificationType)
        {
            return notificationType switch
            {
                NotificationType.email => _emailNotificationService,
                NotificationType.sms => _smsNotificationService,
                _ => throw new ArgumentException()
            };
        }
    }
}
