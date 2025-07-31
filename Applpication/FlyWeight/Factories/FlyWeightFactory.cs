using Domain.FlyWeight.Interfaces;
using System.Collections.Concurrent;

namespace Application.FlyWeight.Factories
{
    //پیاده سازی به صورت جنریک
    public class FlyWeightFactory<TKey, TFlyWeight> where TFlyWeight : IFlyWeight<TKey>
    {
        private readonly ConcurrentDictionary<TKey, TFlyWeight> _flyWeight = new();
        private readonly Func<TKey, TFlyWeight> _factoryMethod;

        public FlyWeightFactory(Func<TKey, TFlyWeight> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }
        public TFlyWeight GetFlyWeight(TKey key)
        {
            return _flyWeight.GetOrAdd(key, _factoryMethod);
        }
    }
}