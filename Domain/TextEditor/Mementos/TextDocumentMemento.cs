namespace Domain.TextDocument.Mementos
{
    public class TextDocumentMemento
    {
        public string Content { get; set; }
        public DateTime SnapShopTime { get; set; }
        public TextDocumentMemento(DateTime snapShopTime, string content)
        {
            SnapShopTime = snapShopTime;
            Content = content;
        }
    }
}
