using Domain.Book.Interfaces;

namespace Infrastructure.Book.Iterators
{
    public class BookIterator : IIterator<Domain.Book.Book>
    {
        protected readonly IReadOnlyList<Domain.Book.Book> _books;

        protected int _position;
        public BookIterator(IEnumerable<Domain.Book.Book> books)
        {
            _books = books.ToList().AsReadOnly();
            _position = -1;
        }

        public virtual bool HasNext() => _position < _books.Count - 1;
        public virtual Domain.Book.Book? Next()
        {
            if (!HasNext())
                return null;
            _position++;
            return _books[_position];
        }

        public virtual void Reset() => _position = -1;
    }
}
