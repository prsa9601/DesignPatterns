namespace Domain.Product.Strategies
{
    public interface IMeasurementStrategy
    {
        public string Unit { get; }
        bool Validate(double quantity); //Quantity = کمیت
        decimal CalculateTotalPrice(Domain.Product.ValueObjects.Money basePrice, double quantity);
    }
}