using Application.FlyWeight.Factories;
using Application.FlyWeight.Models;
using Domain.FlyWeight.Entities;
using Domain.FlyWeight.Interfaces.Repositiry;

namespace Application.FlyWeight.Services
{
    public class ProductService
    {
        private readonly BrandFactory _brandFactory;
        private readonly CategoryFactory _categoryFactory;
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, CategoryFactory categoryFactory, BrandFactory brandFactory)
        {
            _productRepository = productRepository;
            _categoryFactory = categoryFactory;
            _brandFactory = brandFactory;
        }

        public ProductModel GetProduct(Guid productId)
        {
            var product = _productRepository.GetProduct(productId);

            //دریافت دیتا از ریپازیتوری ها
            var brandModel = new Brand(Guid.NewGuid(),
                "Default Name", "Default Logo Base 64");

            var categoryModel = new Category(Guid.NewGuid(),
                "Default Title", "Default Description");

            //استاده از FlyWeight
            var brand = _brandFactory.GetBrand(product.BrandId,
                brandModel.Name, brandModel.LogoBase64);

            var category = _categoryFactory.GetCategory(product.CategoryId,
                categoryModel.Title, categoryModel.Description);

            //عملیات با داده غیر ذاتی
            brand.Operation(brandModel.LogoBase64);
            category.Operation(category.Description);

            return new ProductModel
            {
                Id = product.Id,
                Brand = new BrandModel
                {
                    Id = brand.Id,
                    LogoBase64 = brand.LogoBase64,
                    Name = brand.Name,
                },
                Name = product.Name,
                Price = product.Price,
                Category = new CategoryModel
                {
                    Id = category.Id,
                    Description = category.Description,
                    Title = category.Title,
                }
            };
        }
    }
}
