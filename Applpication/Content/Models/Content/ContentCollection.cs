using Domain.Content.Interface;

namespace Application.Content.Models.Content
{
    public class ContentCollection : IContentComponent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public ContentType Type { get; } = ContentType.Collection;

        private readonly List<IContentComponent> _children = new();

        public IEnumerable<IContentComponent>? GetChildren() => _children.AsReadOnly();

        public void AddChild(IContentComponent component)
        {
            if (component == this)
                throw new InvalidOperationException("Cannot add collection to itself");

            _children.Add(component);
        }

        public void RemoveChild(IContentComponent component) => _children.Remove(component);

        public int CalculateReadTime() =>
            _children.Sum(child => child.CalculateReadTime());
    }
}
