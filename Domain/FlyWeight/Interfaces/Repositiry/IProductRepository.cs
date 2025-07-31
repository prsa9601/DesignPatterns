using Domain.FlyWeight.Entities;
using System.Net.Http.Headers;

namespace Domain.FlyWeight.Interfaces.Repositiry
{
    public interface IProductRepository
    {
        ProductData GetProduct(Guid id);
    }
}
