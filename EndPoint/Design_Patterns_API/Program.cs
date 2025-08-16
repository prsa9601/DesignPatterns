using Application.Content.Services;
using Application.Decorator.Interfaces;
using Application.FlyWeight.Factories;
using Application.FlyWeight.Services;
using Application.GraphicDesign.Factories;
using Application.GraphicDesign.Services;
using Application.Notification.Commands.SendNotification;
using Application.Notification.Fallback;
using Application.Notification.Services;
using Application.Order.Builder;
using Application.Order.Handlers;
using Application.Order.ObserverDesign;
using Application.Order.Services;
using Application.Order.States.Interfaces;
using Application.Order.Strategies;
using Application.Order.Visitors;
using Application.Order.Visitors.Services;
using Application.Payment.Services;
using Application.Product.Visitors;
using Application.Proxy.Services;
using Application.Report.Interfaces;
using Application.Shape.Factory;
using Application.Shape.Interface;
using Application.TextEditor.History;
using Application.User.Builders;
using Application.User.Mediators;
using Application.User.Services;
using Applpication;
using Domain.Book.Interfaces;
using Domain.FlyWeight.Entities;
using Domain.FlyWeight.Interfaces.Repositiry;
using Domain.Notification.Interfaces;
using Domain.Notification.Services;
using Domain.Order.Interfaces;
using Domain.Order.Services.Builder;
using Domain.Order.Services.Factory;
using Domain.Order.Services.ObserverDesign;
using Domain.Order.Services.StrategyDesign;
using Domain.Proxy.Interfaces;
using Domain.TextDocument.Mementos;
using Domain.TextEditor.Repository;
using Domain.User.Builders;
using Domain.User.Mediators;
using Infrastructure.Book.Collections;
using Infrastructure.Communication.NotificationServices;
using Infrastructure.FlyweightPattern.Repositories;
using Infrastructure.NotificationSenders;
using Infrastructure.NotificationSenders.Fallback;
using Infrastructure.Notifier.Decorators;
using Infrastructure.Order.Factories;
using Infrastructure.Order.Services;
using Infrastructure.Order.States;
using Infrastructure.Order.Visitors;
using Infrastructure.Payment.Adapter;
using Infrastructure.Payment.LegacyPayment;
using Infrastructure.Proxy.Services;
using Infrastructure.Report.Excel;
using Infrastructure.Report.PDF;
using Infrastructure.Shape.Rendering;
using Infrastructure.TextEditor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
builder.Services.AddScoped<IOrderObserver, Infrastructure.Order.Services.InventoryService>();
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


#region Proxy

builder.Services.AddScoped<Infrastructure.Proxy.Services.InventoryService>();
builder.Services.AddScoped<IInventoryService>(provider =>
{
    var realService = provider.GetRequiredService
    <Infrastructure.Proxy.Services.InventoryService>();
    var logger = provider.GetRequiredService<ILogger<InventoryServiceProxy>>();
    return new InventoryServiceProxy(realService, logger);
});
builder.Services.AddScoped<InventoryManager>();


//builder.Services.AddScoped<IInventoryService>(provider =>
//    new InventoryServiceProxy(
//        inventoryService: provider.GetRequiredService<Domain.Proxy.Interfaces.IInventoryService>(),
//        logger: provider.GetRequiredService<ILogger<InventoryServiceProxy>>()
//        )
//);

#endregion

#region ChainOfRespinsibility

builder.Services.AddTransient<ValidationHandler>();
builder.Services.AddTransient<ShippingHandler>();
builder.Services.AddTransient<DiscountHandler>();
builder.Services.AddTransient<ApprovalHandler>();

builder.Services.AddTransient<IOrderHandler>(provider =>
{
    var validation = provider.GetRequiredService<ValidationHandler>();
    var discount = provider.GetRequiredService<DiscountHandler>();
    var shipping = provider.GetRequiredService<ShippingHandler>();
    var approval = provider.GetRequiredService<ApprovalHandler>();

    validation.SetNext(discount)
    .SetNext(shipping)
    .SetNext(approval);

    return validation;
});

builder.Services.AddScoped<OrderProcessingService>();

#endregion

#region Mediator

builder.Services.AddScoped<IChatMediator, ChatMediator>();
builder.Services.AddScoped<ChatService>();

#endregion

#region Iterator
builder.Services.AddSingleton<IBookCollection, BookCollections>();
#endregion


#region State
builder.Services.AddScoped<IOrderStateFactory, OrderStateFactory>();
builder.Services.AddTransient<PendingState>();
builder.Services.AddTransient<ConfirmedState>();
builder.Services.AddTransient<ProcessingState>();
builder.Services.AddTransient<ShippedState>();
builder.Services.AddTransient<CancelledState>();
#endregion

#region Visitor

builder.Services.AddScoped<OrderTaxCalculate>();
builder.Services.AddScoped<OrderReportGenerator>();
builder.Services.AddScoped<ProductDiscountVisitor>();
builder.Services.AddScoped<OrderProcessor>();
builder.Services.AddScoped<ExportVisitor>(provider => new ExportVisitor
(provider.GetRequiredService<IConfiguration>()["ExportPath"]!));
#endregion

#region Memento 

builder.Services.AddScoped<DocumentHistory>();
builder.Services.AddScoped<IMementoRepository, MementoRepository>();
#endregion

#region Template Method

builder.Services.AddScoped<EmailNotificationSender>();
builder.Services.AddScoped<SmsNotificationSender>();
builder.Services.AddScoped<PushNotificationSender>();
//builder.Services.AddScoped<INotificationSender>(provider =>
//{
//    var sendrs = new List<INotificationSender>
//    {
//        provider.GetRequiredService<EmailNotificationSender>(),
//        provider.GetRequiredService<SmsNotificationSender>(),
//        provider.GetRequiredService<PushNotificationSender>()
//    };
//    return new FallbackNotificationSender(sendrs);
//});
builder.Services.AddScoped<IFallbackNotificationSender, FallbackNotificationSender>();
builder.Services.AddScoped<INotificationSender, FallbackNotificationSender>();

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
