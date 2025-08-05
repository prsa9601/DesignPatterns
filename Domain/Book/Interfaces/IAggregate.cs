namespace Domain.Book.Interfaces
{
    //مثال کلی
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }
}
