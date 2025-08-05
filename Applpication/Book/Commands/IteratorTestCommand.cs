using Domain.Book.Interfaces;
using MediatR;

namespace Application.Book.Commands
{
    public class IteratorTestCommand : IRequest
    {
    }
    public class IteratorTestCommandHandler : IRequestHandler<IteratorTestCommand>
    {
        private IBookCollection _bookCollection;

        public IteratorTestCommandHandler(IBookCollection bookCollection)
        {
            _bookCollection = bookCollection;
        }

        public Task<Unit> Handle(IteratorTestCommand request, CancellationToken cancellationToken)
        {
            _bookCollection.AddBook(new Domain.Book.Book
            {
                Id = Guid.NewGuid(),
                Name = "Default Name 1",
                Price = 1
            });
            _bookCollection.AddBook(new Domain.Book.Book
            {
                Id = Guid.NewGuid(),
                Name = "Default Name 2",
                Price = 12
            });
            _bookCollection.AddBook(new Domain.Book.Book
            {
                Id = Guid.NewGuid(),
                Name = "Default Name 3",
                Price = 13
            });
            _bookCollection.AddBook(new Domain.Book.Book
            {
                Id = Guid.NewGuid(),
                Name = "Default Name 4",
                Price = 14
            });
            _bookCollection.AddBook(new Domain.Book.Book
            {
                Id = Guid.NewGuid(),
                Name = "Default Name 5",
                Price = 15
            });
            _bookCollection.AddBook(new Domain.Book.Book
            {
                Id = Guid.NewGuid(),
                Name = "Default Name 6",
                Price = 25
            });
            var iterator = _bookCollection.GetIterator();
            var priceIterator = _bookCollection.GetPriceIterator(13);

            List<Domain.Book.Book?> book = new();
            List<Domain.Book.Book?> bookFilter = new();

            while (iterator.HasNext())
            {
                book.Add(iterator.Next());
            }

            while (priceIterator.HasNext())
            {
                bookFilter.Add(priceIterator.Next());
            }
            return Task.FromResult(Unit.Value);
        }
    }
}
