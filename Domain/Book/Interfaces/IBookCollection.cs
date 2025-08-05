namespace Domain.Book.Interfaces
{
    public interface IBookCollection
    {
        IIterator<Book> GetIterator();
        IIterator<Book> GetPriceIterator(int minPrice);
        void AddBook(Book book);
    }
}
