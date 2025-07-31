namespace Domain.Content.Interface
{
    //Composite
    public interface IContentComponent
    {
        Guid Id { get; }
        string Title { get; }
        ContentType Type { get; } // enum {Article, Video, Collection}
        IEnumerable<IContentComponent>? GetChildren();
        void AddChild(IContentComponent component);
        void RemoveChild(IContentComponent component);
        int CalculateReadTime(); // عملیات مشترک
    }

    public enum ContentType
    {
        Article,
        Video,
        Collection
    }
}
