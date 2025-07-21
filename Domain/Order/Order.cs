namespace Domain.Order
{
    public class Order
    {
        private Guid Id { get; set; }
        public Dictionary<Guid, int>? Products { get; set; }//id, number
        public Guid UserId { get; set; }
        public Money TotalPrice { get; set; }
        private bool IsFinally { get; set; } = false;
        //public Order(Guid userId, Dictionary<Guid, int> products)
        //{
        //    userId == null ? throw new ArgumentNullException() : UserId = userId;
        //    Products = products;
        //}
        public Order()
        {
            
        }
        public void Finally()
        {
            IsFinally = true;
        }
    }
}
