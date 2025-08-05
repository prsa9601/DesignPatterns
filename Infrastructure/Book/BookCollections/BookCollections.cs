using Domain.Book;
using Domain.Book.Interfaces;
using Infrastructure.Book.Iterators;

namespace Infrastructure.Book.Collections
{
    public class BookCollections : IBookCollection
    {
        private readonly List<Domain.Book.Book> _books = new();
        public void AddBook(Domain.Book.Book book) => _books.Add(book);

        public IIterator<Domain.Book.Book> GetIterator() => new BookIterator(_books);

        public IIterator<Domain.Book.Book> GetPriceIterator(int minPrice)
            => new GetPriceIterator(_books, minPrice);
    }
}
