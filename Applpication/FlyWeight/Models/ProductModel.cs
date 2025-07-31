using Domain.FlyWeight.Interfaces;

namespace Application.FlyWeight.Models
{
    public class ProductModel
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public CategoryModel Category { get; set; }
            public BrandModel Brand { get; set; }
    }
    public class CategoryModel
    {
    
        public Guid Id { get; set; }
        public string Title { get; set; } //ذاتی
        public string Description { get; set; } //ذاتی

       
    }
    public class BrandModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //داده ذاتی 
        public string LogoBase64 { get; set; } //داده ذاتی = مشترک

     
    }
}
