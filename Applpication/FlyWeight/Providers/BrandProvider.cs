using Application.FlyWeight.Factories;
using Domain.FlyWeight.Entities;
using Domain.FlyWeight.Interfaces.Providers;

namespace Application.FlyWeight.Providers
{
    public class BrandProvider : IBrandProvider
    {
        private readonly BrandFactory _factory;

        public BrandProvider(BrandFactory factory)
        {
            _factory = factory;
        }

        public Brand GetBrandAsync(Guid brandId)
        {
            var brand = new Brand(Guid.NewGuid(),
                "Name Category From Brand Provider",
                "Logo Base64 Category From Brand Provider");

            return _factory.GetBrand(brand.Id, brand.Name, brand.LogoBase64);
        }
    }
}
