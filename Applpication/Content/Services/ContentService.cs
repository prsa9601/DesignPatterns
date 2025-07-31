using Application.Content.Models.Content;
using Domain.Content.Interface;

namespace Application.Content.Services
{
    //Composite
    // استفادش میتونه توی کامندهندلر باشه
    public class ContentService
    {
        public List<IContentComponent> GetContentTree(Guid rootId)
        {
            List<IContentComponent> list = new List<IContentComponent>();
            for (int i = 0; i < 3; i++)
            {
                list.Add(new Video
                {
                    Content = default(string),
                    DurationMinutes = default(int),
                    Title = default(string)
                });
                for (int j = 6; j < 7; j++)
                {
                    list.Add(new Video
                    {
                        Content = $"{default(string)}+j",
                        DurationMinutes = j,
                        Title = $"{default(string)}+j"
                    });
                }
                for (int r = 9; r < 10; r++)
                {
                    list.Add(new Video
                    {
                        Content = $"{default(string)}+r",
                        DurationMinutes = r,
                        Title = $"{default(string)}+r"
                    });
                }
            }
            return list;
        }
        public int CalculateTotalReadTime(IContentComponent root)
        {
            return root.CalculateReadTime(); // عملیات بازگشتی روی کل درخت
        }
    }
}
