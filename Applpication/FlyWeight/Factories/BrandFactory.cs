using Domain.FlyWeight.Entities;
using System.Collections.Concurrent;

namespace Application.FlyWeight.Factories
{
    public class BrandFactory
    {
        private readonly ConcurrentDictionary<Guid, Brand> _brands = new();

        public Brand GetBrand(Guid id, string name, string logo)
        {
            return _brands.GetOrAdd(id, brand => new Brand(id, name, logo));
        }
    }
}
