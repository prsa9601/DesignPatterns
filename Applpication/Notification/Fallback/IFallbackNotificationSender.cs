using Domain.Notification.Interfaces;

namespace Application.Notification.Fallback
{
    public interface IFallbackNotificationSender: INotificationSender
    {
        public void AddService(INotificationSender sender);
    }
}
