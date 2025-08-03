using Domain.User.Mediators;

namespace Application.User.Services
{
    public class ChatService 
    {
        private readonly IChatMediator _mediator;

        public ChatService(IChatMediator mediator)
        {
            _mediator = mediator;
        }
        public void SendMessage(string message, Domain.User.User sender)
        {
            Console.WriteLine($"{sender.UserName} ارسال کرد: {message}");
            _mediator.SendMessage(sender, message);
        }
    }
}
