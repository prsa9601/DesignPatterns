using Domain.Notification.Interfaces;

namespace Domain.Notification.Services
{
    //Dependency Inversion & Factory Design
    public interface ISmsNotificationService : INotificationService
    {
    }
}
