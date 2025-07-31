using Application.GraphicDesign.Factories;

namespace Application.GraphicDesign.Services
{
    public class RenderingService
    {
        private readonly FontFactory _fontFactory;

        public RenderingService(FontFactory fontFactory)
        {
            _fontFactory = fontFactory;
        }

        public string RenderText(string fontText, string text, int size)
        {
            var font = _fontFactory.GetFont(fontText);
            return font.Render(text, size);
        }
    }
}
