using Domain.FlyWeight.Entities;
using Domain.FlyWeight.Interfaces.Repositiry;

namespace Infrastructure.FlyweightPattern.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductData GetProduct(Guid id)
        {
            return new ProductData()
            {
                Id = id,
                BrandId = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Name = "Default Product Name " +
                "From Product Repository In Infrastructure Layer",
                Price = 129007985,
            };
        }
    }
}
