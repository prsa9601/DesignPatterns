using Application.Shape.Factory;
using Application.Shape.Interface;
using Application.Shape.RefinedAbstraction;
using MediatR;

namespace Application.Shape.Commands
{
    public class ShapePainterCommand : IRequest
    {
    }
    public class ShapePainterCommandHandler : IRequestHandler<ShapePainterCommand>
    {
        private readonly IRasterRenderer _rasterRenderer;
        private readonly IVectorRenderer _vectorRenderer;

        public ShapePainterCommandHandler(IVectorRenderer vectorRenderer, IRasterRenderer rasterRenderer)
        {
            _vectorRenderer = vectorRenderer;
            _rasterRenderer = rasterRenderer;
        }

        public Task<Unit> Handle(ShapePainterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var circle1 = new Circle(_vectorRenderer, 18);
                var circle2 = new Circle(_rasterRenderer, 18);

                var square1 = new Square(_vectorRenderer, 18);
                var square2 = new Square(_rasterRenderer, 18);
                
                circle1.Draw();
                circle2.Draw();

                square1.Draw();
                square2.Draw();

                return Task.FromResult(Unit.Value);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
