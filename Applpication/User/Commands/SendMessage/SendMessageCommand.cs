using Application.User.Services;
using Domain.User;
using Domain.User.Mediators;
using MediatR;

namespace Application.User.Commands.SendMessage
{
    public class SendMessageCommand : IRequest
    {
    }
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IChatMediator _mediator;
        private readonly ChatService _service;

        public SendMessageCommandHandler(IChatMediator mediator, ChatService service)
        {
            _mediator = mediator;
            _service = service;
        }

        public Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var user1 = new Domain.User.User() { UserName = "Ali"};
            var user2 = new Domain.User.User() { UserName = "Hossein"};
            var user3 = new Domain.User.User() { UserName = "Mohammad"};
            var user4 = new Domain.User.User() { UserName = "Hassan"};

            _mediator.RegisterUser(user1);
            _mediator.RegisterUser(user2);
            _mediator.RegisterUser(user3);
            _mediator.RegisterUser(user4);

            _service.SendMessage("Salam", user1);

            return Task.FromResult(Unit.Value);
        }
    }
}
