using Domain.TextDocument.Mementos;
using Domain.TextEditor.Repository;

namespace Infrastructure.TextEditor
{
    //ذخیره سازی دائمی نسخه های سند
    //DocumentSnapshot
    public class MementoRepository : IMementoRepository
    {
        private readonly Dictionary<Guid, List<TextDocumentMemento>> _snapshots = new();

        public void AddSnapshot(Guid documentId, TextDocumentMemento memento)
        {
            if(!_snapshots.ContainsKey(documentId))
                _snapshots[documentId] = new List<TextDocumentMemento>();
            
            _snapshots[documentId].Add(memento);
        }
        public IReadOnlyList<TextDocumentMemento> GetSnapshots(Guid documentId)
        {
            return _snapshots.TryGetValue(documentId, out var snapshots)
                ?snapshots.AsReadOnly()
                : new List<TextDocumentMemento>().AsReadOnly();
        }
    }
}
