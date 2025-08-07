namespace Domain.Order
{
    public enum OrderStatus
    {
        Draft,
        Pending,       // در انتظار پرداخت
        Processing,    // در حال پردازش
        Shipped,       // ارسال شده
        Confirmed,     // تکمیل شده
        //Completed,     // تکمیل شده
        //OnHold,        // در حال آماده‌سازی
        Cancelled      // لغو شده
    }
}
