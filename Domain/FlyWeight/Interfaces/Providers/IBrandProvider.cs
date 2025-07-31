using Domain.FlyWeight.Entities;

namespace Domain.FlyWeight.Interfaces.Providers
{
    public interface IBrandProvider
    {
        Brand GetBrandAsync(Guid brandId);
    }
}
