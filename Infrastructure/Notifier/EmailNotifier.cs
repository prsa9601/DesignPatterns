using Application.Decorator.Interfaces;

namespace Infrastructure.Notifier
{
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
             Console.WriteLine($"Email Is Send.  {message}");
        }
    }
}
