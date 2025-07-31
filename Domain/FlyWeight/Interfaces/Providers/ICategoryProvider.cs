using Domain.FlyWeight.Entities;

namespace Domain.FlyWeight.Interfaces.Providers
{
    public interface ICategoryProvider
    {
        Category GetCategoryAsync(Guid categoryId);
    }
}
