using Application.Notification.Services;
using Domain.Notification;

namespace Infrastructure.NotificationSenders
{
    public class EmailNotificationSender : NotificationSenderTemplateMethod
    {
        protected override void Dispatch(NotificationMessage message)
        {
            //پیاده سازی ارسال واقعی ایمیل
            Console.WriteLine($"ارسال ایمیل به {message.To}");
            Console.WriteLine($"موضوع: {message.Subject}");
            Console.WriteLine($"متن: {message.Body}");
        }
        protected override void Authenticate()
        {
            //اهراز هویت خاص سرویس ایمیل
            Console.WriteLine("اهراز هویت با SMTP Server انجام شد");
        }
    }
}
