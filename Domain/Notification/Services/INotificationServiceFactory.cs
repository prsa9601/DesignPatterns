using Domain.Notification.Enum;
using Domain.Notification.Interfaces;

namespace Domain.Notification.Services
{
    //Dependency Inversion & Factory Design
    public interface INotificationServiceFactory
    {
        INotificationService Create(NotificationType notificationType);
    }
}
