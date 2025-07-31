using Domain.Product.ValueObjects;

namespace Domain.Product.Strategies
{
    // استراتژی برای محصولات تعدادی
    public class CountableStrategy : IMeasurementStrategy
    {
        public string Unit => "عدد";

        public bool Validate(double quantity)
        {
            return quantity >= 1 && quantity % 1 == 0; // فقط اعداد صحیح
        }

        public decimal CalculateTotalPrice(Domain.Product.ValueObjects.Money basePrice, double quantity)
        {
            return basePrice.Amount * (decimal)quantity;
        }
    }
}
