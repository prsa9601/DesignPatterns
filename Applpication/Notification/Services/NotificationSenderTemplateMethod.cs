using Domain.Notification;
using Domain.Notification.Interfaces;
using System.Reflection;

namespace Application.Notification.Services
{
    //TemplateMethod
    public abstract class NotificationSenderTemplateMethod : INotificationSender
    {
        public void Send(NotificationMessage message)
        {
            ValidateMessage(message);
            PrepareMessageTemplate(message);
            Authenticate();
            Dispatch(message);
            LogNotification(message);
        }

        protected abstract void Dispatch(NotificationMessage message);

        protected virtual void ValidateMessage(NotificationMessage message)
        {
            if (string.IsNullOrEmpty(message.To))
                throw new ArgumentException("گیرنده پیام مشخص نیست");

            if (string.IsNullOrEmpty(message.Body))
                throw new ArgumentException("متن پیام نمیتواند خالی باشد");
        }
        protected virtual void PrepareMessageTemplate(NotificationMessage message)
        {
            message.Body += "\n\n--\nفروشگاه آنلاین ما";
        }
        protected virtual void Authenticate()
        {
            Console.WriteLine("اهراز هویت عمومی انجام شد");
        }
        protected virtual void LogNotification(NotificationMessage message)
        {
            Console.WriteLine($"پیام به {message.To} ارسال شد");
        }
    }
}
