using Application.Content.Services;
using Domain.Content.Interface;
using MediatR;

namespace Application.Content.Commands
{
    //Composite
    public class CreateContentCommand : IRequest<List<IContentComponent>>
    {
    }
    public class CreateContentCommandHandler : IRequestHandler<CreateContentCommand, List<IContentComponent>>
    {
        private readonly ContentService _contentService;

        public CreateContentCommandHandler(ContentService contentService)
        {
            _contentService = contentService;
        }

        public Task<List<IContentComponent>> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var result = _contentService.GetContentTree(new Guid());
            return Task.FromResult(result);
        }
    }
}
