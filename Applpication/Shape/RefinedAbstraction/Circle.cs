using Application.Shape.Interface;

namespace Application.Shape.RefinedAbstraction
{
    internal class Circle : Shape.Abstraction.Shape
    {
        private readonly float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }
    }
}
