using Domain.FlyWeight.Entities;
using System.Collections.Concurrent;

namespace Application.FlyWeight.Factories
{
    public class CategoryFactory
    {
        private readonly ConcurrentDictionary<Guid, Category> _category = new();
        public Category GetCategory(Guid id, string title, string description)
        {
            return _category.GetOrAdd(id, category => new Category(id, title, description));
        }
    }
}
