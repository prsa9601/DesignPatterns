using Domain.User.Builders;

namespace Application.User.Builders
{
    //Implement Builder Design Pattern
    public class UserBuilder : IUserBuilder
    {
        private string _userName;
        private int _age;
        private string _password;
        public Domain.User.User Build()
        {
            return new Domain.User.User()
            {
                UserName = _userName,
                Age = _age,
                Password = _password
            };
        }

        public IUserBuilder WithAge(int age)
        {
            _age = age;
            return this;
        }

        public IUserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public IUserBuilder WithUserName(string userName)
        {
            _userName = userName;
            return this;
        }
    }
}
