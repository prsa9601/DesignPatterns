using Domain.FlyWeight.Interfaces;

namespace Domain.FlyWeight.Entities
{
    public class Brand : IFlyWeight<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //داده ذاتی 
        public string LogoBase64 { get; set; } //داده ذاتی = مشترک

        public Guid Key => Id;

        public Brand(Guid id, string name, string logoBase64)
        {
            //Id = Guid.NewGuid();    
            Id = id;
            Name = name;
            LogoBase64 = logoBase64;
        }

        public void Operation(string extrinsicData)
        {
            Console.WriteLine($"Brand: {Name} , ExtrinsicData: {extrinsicData}");
        }
    }
}
