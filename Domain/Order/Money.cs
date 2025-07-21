namespace Domain.Order
{
    public class Money
    {
        public long RialValue { get; private set; }

        public Money(long value)
        {
            if (value < 0)
                throw new ArgumentException();

            RialValue = value;
        }

        public static Money FromRial(long price)
        {
            return new Money(price * 10);
        }
        public static Money FromTooman(long price)
        {
            return new Money(price / 10);
        }
        public static Money operator +(Money firstMoney, Money secondMoney)
        {
            //return firstMoney + secondMoney;
            return new Money(firstMoney.RialValue + secondMoney.RialValue);
        }
        public static Money operator -(Money firstMoney, Money secondMoney)
        {
            //return firstMoney + secondMoney;
            return new Money(firstMoney.RialValue - secondMoney.RialValue);
        }
        public override string ToString()
        {
            return RialValue.ToString("#, 0");
        }
    }
}
