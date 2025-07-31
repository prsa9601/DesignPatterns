using Domain.Content.Interface;

namespace Application.Content.Models.Content
{
    //Composite
    public class Article : IContentComponent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public ContentType Type { get; } = ContentType.Article;
        public string Content { get; set; }
        public int WordCount => Content.Split(' ').Length;

        public void AddChild(IContentComponent component)
        {
            throw new NotImplementedException();
        }

        public int CalculateReadTime()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContentComponent>? GetChildren()
        {
            throw new NotImplementedException();
        }

        public void RemoveChild(IContentComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
