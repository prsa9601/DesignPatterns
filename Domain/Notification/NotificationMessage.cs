namespace Domain.Notification
{
    public class NotificationMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsUrgent { get; set; }
    }
}
