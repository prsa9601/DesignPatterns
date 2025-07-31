using Domain.Product.ValueObjects;

namespace Domain.Product.Strategies
{
    // استراتژی برای محصولات وزنی
    public class WeightStrategy : IMeasurementStrategy
    {
        public string Unit => "کیلوگرم";

        public bool Validate(double quantity)
        {
            return quantity > 0; // هر مقدار مثبت
        }

        public decimal CalculateTotalPrice(Money basePrice, double quantity)
        {
            return basePrice.Amount * (decimal)quantity;
        }
    }
}
