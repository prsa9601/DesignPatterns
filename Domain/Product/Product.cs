using Domain.Product.Strategies;
using Domain.Product.Visitors;

namespace Domain.Product
{
    public class Product
    {
        public Guid Id { get; }
        public string Name { get; }
        public Domain.Product.ValueObjects.Money Price { get; set; }
        public IMeasurementStrategy Measurement { get; }

        public Product(string name, Domain.Product.ValueObjects.Money price, IMeasurementStrategy measurement)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Measurement = measurement ?? throw new ArgumentNullException(nameof(measurement));
        }
        public void UpdatePrice(decimal newPrice) => Price = new ValueObjects.Money((decimal)newPrice, "IR");

        public bool ValidateQuantity(double quantity) => Measurement.Validate(quantity);

        public decimal CalculateTotalPrice(double quantity)
        {
            if (!ValidateQuantity(quantity))
                throw new ArgumentException("مقدار نامعتبر برای واحد اندازه‌گیری");

            return Measurement.CalculateTotalPrice(Price, quantity);
        }
        //visitor pattern Integration
        public void Accept(IProductVisitor productVisitor) => productVisitor.Visit(this);
    }
}
