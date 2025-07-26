using System.Reflection.Metadata.Ecma335;

namespace Domain.User
{
    //Prototype
    public class User : ICloneable
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }

        //کپی سطحی
        //ShallowCopy
        public object Clone()
        {
            return (User)this.MemberwiseClone();
            //return new User()
            //{
            //    UserName = this.UserName,
            //    Password = this.Password,
            //    Age = this.Age,
            //};
        }
        public object DeepClone()
        {
            return new User
            {
                UserName = this.UserName,
                Age = this.Age,
                Password = this.Password,
                Address = new Address { City = this.Address.City }
            };
        }
    }
}
