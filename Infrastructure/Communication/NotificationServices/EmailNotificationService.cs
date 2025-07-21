using Domain.Notification.Interfaces;
using Domain.Notification.Services;

namespace Infrastructure.Communication.NotificationServices
{
    public class EmailNotificationService : IEmailNotificationService
    {
        //Dependency Inversion & Factory Design
        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }
}
