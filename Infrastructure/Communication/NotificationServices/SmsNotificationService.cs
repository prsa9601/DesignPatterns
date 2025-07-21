using Domain.Notification.Interfaces;
using Domain.Notification.Services;

namespace Infrastructure.Communication.NotificationServices
{
    //Dependency Inversion & Factory Design
    public class SmsNotificationService : ISmsNotificationService
    {
        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }
}
