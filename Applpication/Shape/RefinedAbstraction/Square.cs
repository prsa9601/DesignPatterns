using Application.Shape.Abstraction;
using Application.Shape.Interface;

namespace Application.Shape.RefinedAbstraction
{
    public class Square : Application.Shape.Abstraction.Shape
    {
        private readonly float side;
        public Square(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }

        public override void Draw()
        {
            renderer.RenderSquare(side);
        }
    }
}
