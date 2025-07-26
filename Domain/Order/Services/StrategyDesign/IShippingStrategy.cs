namespace Domain.Order.Services.StrategyDesign
{
    public interface IShippingStrategy
    {
        //Strategy Pettern
        decimal Calculate(Order order);
    }
}
