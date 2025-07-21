
namespace Domain.Order.Services.Builder
{
    public interface IOrderBuilder
    {
        IOrderBuilder WithUserId(Guid userId);
        IOrderBuilder WithProducts(Dictionary<Guid, int> products);
        IOrderBuilder WithTotalPrice(long totalPrice);
        Order Build();
    }
}
