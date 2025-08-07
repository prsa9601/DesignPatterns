using Domain.TextDocument.Mementos;

namespace Domain.TextDocument
{
    public class TextDocument
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Content { get; private set; } = string.Empty;
        public DateTime LastModified { get; private set; }

        public TextDocument(string content)
        {
            Content = content;
            LastModified = DateTime.Now;
        }


        public void Update(string content)
        {
            Content = content;
            LastModified = DateTime.Now;
        }

        public TextDocumentMemento CreateMemento() =>
            new TextDocumentMemento(LastModified, Content);

        public void Restore(TextDocumentMemento memento)
        {
            Content = memento.Content;
            LastModified = memento.SnapShopTime;
        }
    }
}
