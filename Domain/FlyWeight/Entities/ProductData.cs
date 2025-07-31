using System.Reflection.Metadata.Ecma335;

namespace Domain.FlyWeight.Entities
{
    public class ProductData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
