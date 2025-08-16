using Application.Notification.Services;
using Domain.Notification;

namespace Infrastructure.NotificationSenders
{
    public class PushNotificationSender : NotificationSenderTemplateMethod
    {
        protected override void Dispatch(NotificationMessage message)
        {
            Console.WriteLine($"ارسال پوش نوتیفیکیشن به دستگاه {message.To}");
            Console.WriteLine($"عنوان: {message.Subject}");
            Console.WriteLine($"محتوا: {message.Body}");
        }
        protected override void ValidateMessage(NotificationMessage message)
        {
            base.ValidateMessage(message);

            //if (message.To.Length != 36)
            //    throw new ArgumentException("شناسه دستگاه نا معتبر است.");
        }
    }
}
