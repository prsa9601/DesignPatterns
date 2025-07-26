1 => clone Pattern => Domain.User.User =>(Methods) Clone && DeepClone
2 => Builder Pattern => (Implementation as an interface) Domain.User.Builders.IUserBuilders && Domain.Order.Builder.IOrderBuilder
    => (Implementing interfaces) Application.Order.Builder.OrderBuilder && Application.User.Builders.UserBuilder => (Used in)  Application.Order.Finally && Application.User.Services.AddUser 
3 =>
