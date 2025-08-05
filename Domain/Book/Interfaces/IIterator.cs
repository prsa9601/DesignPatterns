namespace Domain.Book.Interfaces
{
    public interface IIterator<T>
    {
        bool HasNext();
        T? Next();
        void Reset();   
    }
}
