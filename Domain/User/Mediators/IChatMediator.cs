namespace Domain.User.Mediators
{
    public interface IChatMediator
    {
        void RegisterUser(User user);
        void SendMessage(User user, string message);
    }
}
