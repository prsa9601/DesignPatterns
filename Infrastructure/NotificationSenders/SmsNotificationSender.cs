using Application.Notification.Services;
using Domain.Notification;
using System.Net.Mail;

namespace Infrastructure.NotificationSenders
{
    public class SmsNotificationSender : NotificationSenderTemplateMethod
    {
        protected override void Dispatch(NotificationMessage message)
        {
            Console.WriteLine($"ارسال SMS به {message.To}");
            Console.WriteLine($"متن: {message.Body}");
        }
        protected override void PrepareMessageTemplate(NotificationMessage message)
        {
            //base.PrepareMessageTemplate(message);
            message.Body = message.Body.Substring(0, Math.Min(message.Body.Length, 160));
        }
    }
}
