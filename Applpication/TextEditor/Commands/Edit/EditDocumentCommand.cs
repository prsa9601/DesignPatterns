using Application.TextEditor.History;
using Domain.TextDocument;
using Domain.TextEditor.Repository;
using MediatR;

namespace Application.TextEditor.Commands.Edit
{
    public class EditDocumentCommand :IRequest
    {
    }
    public class EditDocumentCommandHandler : IRequestHandler<EditDocumentCommand>
    {
        private readonly DocumentHistory _history;
        private readonly IMementoRepository _mementoRepository;

        public EditDocumentCommandHandler(DocumentHistory history, IMementoRepository mementoRepository)
        {
            _history = history;
            _mementoRepository = mementoRepository;
        }

        public Task<Unit> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
        {
            var document = new TextDocument("Default Content");
            //ثبت وضعیت فعلی
            var memento = document.CreateMemento(); 
            _history.SaveState(memento);
   
            var document2 = new TextDocument("Fake Default Content");
            //ثبت وضعیت فعلی
            var fakeMemento = document2.CreateMemento(); 
            _history.SaveState(fakeMemento);

            //اعمال تغییر جدید
            document.Update("Second Default Content");


            //undo
            var memento2 = _history.Undo();
            document.Restore(memento2!);
            
            //redo
            var memento3 = _history.Redo();
            document.Restore(memento3!);

            _mementoRepository.AddSnapshot(document.Id,memento2!);
            _mementoRepository.AddSnapshot(document.Id,memento3!);

            _mementoRepository.AddSnapshot(document2.Id,memento2!);
            _mementoRepository.AddSnapshot(document2.Id,memento3!);


            var q = _mementoRepository.GetSnapshots(document.Id);
            var q2 = _mementoRepository.GetSnapshots(document2.Id);
            var q3 = _mementoRepository.GetSnapshots(Guid.NewGuid());
            return Task.FromResult(Unit.Value);
        }
    }
}
