using Domain.GraphicDesign.Fonts;
using System.Collections.Concurrent;

namespace Application.GraphicDesign.Factories
{
    public class FontFactory
    {
        private readonly ConcurrentDictionary<string, IFont> _font = new();

        public IFont GetFont(string name)
        {
            return _font.GetOrAdd(name, font => new Font(font));
        }
    }
}
