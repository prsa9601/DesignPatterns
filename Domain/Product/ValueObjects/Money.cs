namespace Domain.Product.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; set; } //Amount = مبلغ
        public string Currency { get; set; } // Currency = ارز
        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentException("مقدار نمی‌تواند منفی باشد");
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("ارز نامعتبر است");

            Amount = amount;
            Currency = currency;
        }

    }
}
