using Application.Decorator.Interfaces;
using System.Text;

namespace Infrastructure.Notifier.Decorators
{
    public class EncryptionDecorator : INotifierDecorator
    {
        public EncryptionDecorator(INotifier notifier) : base(notifier) { }
        public override void Send(string message)
        {
            var encrypt = Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
            Console.WriteLine(encrypt);
            base.Send(message);
        }
    }
}
