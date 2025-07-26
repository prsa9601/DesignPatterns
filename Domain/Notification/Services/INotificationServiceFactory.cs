using Domain.Notification.Enum;
using Domain.Notification.Interfaces;

namespace Domain.Notification.Services
{
    //Dependency Inversion & Factory Method Design
    public interface INotificationServiceFactory
    {
        INotificationService Create(NotificationType notificationType);
    }
}
