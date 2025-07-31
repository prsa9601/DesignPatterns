using Domain.Content.Interface;

namespace Application.Content.Models.Content
{
    //Composite
    public class Video : IContentComponent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public ContentType Type { get; } = ContentType.Video;

        public string Content { get; set; }
        public int WordCount => Content.Split(' ').Length;

        public IEnumerable<IContentComponent>? GetChildren()
        {
            throw new NotImplementedException();
        }

        public void AddChild(IContentComponent component)
      => throw new InvalidOperationException("Video cannot have children");

        public void RemoveChild(IContentComponent component)
            => throw new InvalidOperationException("Video cannot have children");

        public int DurationMinutes { get; set; }

        public int CalculateReadTime() => DurationMinutes;
      
    }
}
