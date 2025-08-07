using Domain.TextDocument.Mementos;

namespace Application.TextEditor.History
{
    //CareTaker
    public class DocumentHistory
    {
        private readonly Stack<TextDocumentMemento> _undoStack = new();
        private readonly Stack<TextDocumentMemento> _redoStack = new();

        public void SaveState(TextDocumentMemento memento)
        {
            _undoStack.Push(memento);
            _redoStack.Clear(); // با هر تغییر جدید، تاریخچه redo پاک می‌شود
        }
        public TextDocumentMemento? Undo() //لغو آخرین تغییرات انجام شده
        {
            if (_undoStack.Count <= 1) return null; // حداقل یه وصعیت باید باقی بمونه

            var current = _undoStack.Pop();
            _redoStack.Push(current);
            return _undoStack.Peek();
        }
        public TextDocumentMemento? Redo() // بازگردانی تغییراتی که قبلاً با Undo لغو شده‌اند
        {
            if(_redoStack.Count <= 0) return null;

            var nextState = _redoStack.Pop();
            _undoStack.Push(nextState);
            return nextState;
        }
        public bool CanUndo => _undoStack.Count > 1;
        public bool CanRedo => _redoStack.Count > 0;
    }
}
