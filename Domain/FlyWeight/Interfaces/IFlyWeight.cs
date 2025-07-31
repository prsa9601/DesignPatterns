namespace Domain.FlyWeight.Interfaces
{
    public interface IFlyWeight<TKey> 
    {
        TKey Key { get; }
        void Operation(string extrinsicData);
    }
}
