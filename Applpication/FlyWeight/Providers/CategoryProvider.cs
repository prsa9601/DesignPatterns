using Application.FlyWeight.Factories;
using Domain.FlyWeight.Entities;
using Domain.FlyWeight.Interfaces.Providers;

namespace Application.FlyWeight.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly CategoryFactory _factory;

        public CategoryProvider(CategoryFactory factory)
        {
            _factory = factory;
        }

        public Category GetCategoryAsync(Guid categoryId)
        {
            var category = new Category(Guid.NewGuid(),
            "Title Category From Brand Provider",
            "Description Category From Brand Provider");

            return _factory.GetCategory(category.Id, category.Title, category.Description);
        }
    }
}
