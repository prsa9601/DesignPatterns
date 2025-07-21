namespace Domain.User.Builders
{
    //Builder Design Pattern
    public interface IUserBuilder
    {
        IUserBuilder WithUserName(string userName);
        IUserBuilder WithPassword(string password);
        IUserBuilder WithAge(int age);
        User Build();
    }
}
