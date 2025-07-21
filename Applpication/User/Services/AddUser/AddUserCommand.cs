using Domain.User.Builders;
using MediatR;

namespace Application.User.Services.AddUser
{
    public class AddUserCommand : IRequest
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }
   
    internal class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserBuilder _builder;

        public AddUserCommandHandler(IUserBuilder builder)
        {
            _builder = builder;
        }

        public Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _builder.WithAge(request.Age).
                WithUserName(request.UserName).WithPassword(request.Password).Build();
            return Task.CompletedTask;
        }
    }
}
