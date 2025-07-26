using Domain.Notification.Interfaces;
using Domain.User;

namespace Domain.Notification.Services
{
    //Dependency Inversion & Factory Design
    public interface IEmailNotificationService : INotificationService
    {
    }
}
