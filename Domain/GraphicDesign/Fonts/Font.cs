namespace Domain.GraphicDesign.Fonts
{
    public class Font : IFont
    {
        private readonly string _name; // داده ذاتی (Intrinsic)

        public Font(string name)
        {
            _name = name;
        }

        public string Render(string text, int size)
        {
           return $"Font: {_name}, Text: {text}, Size: {size}px";
        }
    }
}
