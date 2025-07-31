namespace Infrastructure.FlyweightPattern.DTO
{
    public class ProductData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //public Guid BrandId { get; set; }
        //public string BrandName { get; set; }
        //public string BrandLogo { get; set; }

        //public Guid CategoryId { get; set; }
        //public string CategoryTitle { get; set; }
        //public string CategoryDescription { get; set; }
    }
}
