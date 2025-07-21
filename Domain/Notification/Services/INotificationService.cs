namespace Domain.Notification.Interfaces
{
    //Dependency Inversion & Factory Design
    public interface INotificationService
    {
        void Send(string message);
    }
}
