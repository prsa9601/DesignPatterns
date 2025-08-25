namespace Domain.Notification.Interfaces
{
    public interface INotificationSender
    {
        void Send(NotificationMessage message);
    }
}