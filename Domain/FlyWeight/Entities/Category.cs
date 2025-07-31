using Domain.FlyWeight.Interfaces;

namespace Domain.FlyWeight.Entities
{
    public class Category : IFlyWeight<Guid>
    {
        public Category(Guid id, string title, string description)
        {
            //Id = Guid.NewGuid();
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } //ذاتی
        public string Description { get; set; } //ذاتی

        public Guid Key => Id;

        public void Operation(string extrinsicData)
        {
            Console.WriteLine($"Category: {Title}, ExtrinsicFata : {extrinsicData}");
        }
    }
}
