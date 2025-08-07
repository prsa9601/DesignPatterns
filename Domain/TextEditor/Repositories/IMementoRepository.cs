using Domain.TextDocument.Mementos;

namespace Domain.TextEditor.Repository
{
    //DocumentSnapshot
    public interface IMementoRepository
    {
        IReadOnlyList<TextDocumentMemento> GetSnapshots(Guid documentId);
        void AddSnapshot(Guid documentId, TextDocumentMemento memento);
    }
}
