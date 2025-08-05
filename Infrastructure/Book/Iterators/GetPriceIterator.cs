using Domain.Book.Interfaces;

namespace Infrastructure.Book.Iterators
{
    public class GetPriceIterator : BookIterator
    {
        private readonly int _minPrice;
        public GetPriceIterator(IEnumerable<Domain.Book.Book> books, int minPrice)
            : base(books)
        {
            _minPrice = minPrice;
        }
        public override bool HasNext()
        {
            var nextPosition = _position + 1;
            while (nextPosition < _books.Count)
            {
                if (_books[nextPosition].Price >= _minPrice)
                {
                    return true;
                }
                nextPosition++;
            }
            return false;
        }
        public override Domain.Book.Book? Next()
        {
            if (!HasNext()) return null;
            _position++;
            while (_position < _books.Count)
            {
                if (_books[_position].Price >= _minPrice)
                {
                    return _books[_position];
                }
                _position++;
            }
            return null;
        }
        public override void Reset() => base.Reset();
    }
}
