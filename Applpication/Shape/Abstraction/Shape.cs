using Application.Shape.Interface;

namespace Application.Shape.Abstraction
{
    public abstract class Shape
    {
        protected readonly IRenderer renderer;

        protected Shape(IRenderer render)
        {
            renderer = render;
        }
        public abstract void Draw();
    }
}
