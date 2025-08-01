using Domain.FlyWeight.Entities;

namespace Domain.Unit.Test
{
    public class BrandFixture : IDisposable
    {
        public Brand brand;

        public BrandFixture()
        {
            this.brand = new Brand(Guid.NewGuid(),
                "Default Name In Fixture ", "Default LogoBase64 In Fixture");
        }

        public void Dispose()
        {
           //throw new NotImplementedException();
        }
    }
}
