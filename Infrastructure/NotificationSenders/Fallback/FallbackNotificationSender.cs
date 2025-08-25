using Domain.Notification;
using Domain.Notification.Interfaces;
using Application.Notification.Fallback;

namespace Infrastructure.NotificationSenders.Fallback
{
    public class FallbackNotificationSender : IFallbackNotificationSender
    {
        public List<INotificationSender> senders = new();

        //public FallbackNotificationSender(IEnumerable<INotificationSender> senders)
        //{
        //    this.senders = senders;
        //}

        public void AddService(INotificationSender sender)
        {
            senders.Add(sender);
        }
        public void Send(NotificationMessage message)
        {
            var exception = new List<Exception>();
            foreach (var sender in senders)
            {
                try
                {
                    sender.Send(message);
                    //return;
                }
                catch (Exception ex)
                {
                    exception.Add(ex);
                }
            }
        }
    }
}
