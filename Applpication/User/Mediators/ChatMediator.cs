using Domain.User.Mediators;

namespace Application.User.Mediators
{
    public class ChatMediator : IChatMediator
    {
        private readonly List<Domain.User.User> _users = new List<Domain.User.User>();
        public void RegisterUser(Domain.User.User user)
        {
            _users.Add(user);
        }

        public void SendMessage(Domain.User.User sender, string message)
        {
            foreach (var user in _users.Where(i => i != sender))
            {
                Console.WriteLine($"{user.UserName} دریافت کرد: {message}");
            }
        }
    }
}
