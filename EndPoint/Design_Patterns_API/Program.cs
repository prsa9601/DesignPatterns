using Application.Content.Services;
using Application.Decorator.Interfaces;
using Application.FlyWeight.Factories;
using Application.FlyWeight.Services;
using Application.GraphicDesign.Factories;
using Application.GraphicDesign.Services;
using Application.Notification.Commands.SendNotification;
using Application.Order.Builder;
using Application.Order.ObserverDesign;
using Application.Order.Strategies;
using Application.Payment.Services;
using Application.Report.Interfaces;
using Application.Shape.Factory;
using Application.Shape.Interface;
using Application.User.Builders;
using Applpication;
using Domain.FlyWeight.Entities;
using Domain.FlyWeight.Interfaces.Repositiry;
using Domain.Notification.Interfaces;
using Domain.Notification.Services;
using Domain.Order.Services.Builder;
using Domain.Order.Services.Factory;
using Domain.Order.Services.ObserverDesign;
using Domain.Order.Services.StrategyDesign;
using Domain.User.Builders;
using Infrastructure.Communication.NotificationServices;
using Infrastructure.FlyweightPattern.Repositories;
using Infrastructure.Notifier.Decorators;
using Infrastructure.Order.Factories;
using Infrastructure.Order.Services;
using Infrastructure.Payment.Adapter;
using Infrastructure.Payment.LegacyPayment;
using Infrastructure.Report.Excel;
using Infrastructure.Report.PDF;
using Infrastructure.Shape.Rendering;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ??? CommandHandler (??????? ?? ???? ?????? ?? MediatR ????? ??????)
builder.Services.AddMediatR(typeof(SendNotificationCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(Class1).Assembly);


#region Builders

builder.Services.AddScoped<IUserBuilder, UserBuilder>();
builder.Services.AddScoped<IOrderBuilder, OrderBuilder>();

#endregion

builder.Services.AddScoped<ISmsNotificationService, SmsNotificationService>();
builder.Services.AddScoped<IEmailNotificationService, EmailNotificationService>();
builder.Services.AddScoped<INotificationServiceFactory, NotificationServiceFactory>();


#region Observers

builder.Services.AddScoped<IOrderObserver, EmailSender>();
builder.Services.AddScoped<IOrderObserver, InventoryService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IOrderServiceFactory, OrderObserverFactory>();
#endregion


#region Strategy

builder.Services.AddScoped<IShippingStrategy, ExpressShipping>();
builder.Services.AddScoped<IShippingStrategy, StandardShipping>();
#endregion

#region Abstraction
builder.Services.AddScoped<IReportFactory, ExcelReportFactory>();
builder.Services.AddScoped<IReportFactory, PDFReportFactory>();
#endregion

#region Adapter

builder.Services.AddScoped<IPaymentService, LegacyPaymentAdapter>();
builder.Services.AddScoped<LegacyPaymentService>();

#endregion


#region Bridge

builder.Services.AddScoped<IRasterRenderer, RasterRenderer>();
builder.Services.AddScoped<IVectorRenderer, VectorRenderer>();

#endregion


#region Composite

builder.Services.AddScoped<ContentService>();
//builder.Services.AddScoped<IVectorRenderer, VectorRenderer>();

#endregion


#region Decorator

builder.Services.AddScoped<INotifier, Infrastructure.Notifier.EmailNotifier>();
builder.Services.Decorate<INotifier, Infrastructure.Notifier.Decorators.EncryptionDecorator>();
builder.Services.Decorate<INotifier, Infrastructure.Notifier.Decorators.LoggingDecorator>();
//builder.Services.AddScoped<INotifierDecorator, LoggingDecorator>();
//builder.Services.AddScoped<INotifierDecorator, EncryptionDecorator>();

#endregion


#region Flyweight 

builder.Services.AddSingleton<FontFactory>();
builder.Services.AddScoped<RenderingService>();

#endregion


#region Flyweight2

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<CategoryFactory>();
builder.Services.AddSingleton<BrandFactory>();

#endregion



builder.Services.AddControllers();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
