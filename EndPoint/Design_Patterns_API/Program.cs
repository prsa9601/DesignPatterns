using Application.Notification.Services.SendNotification;
using Application.Order.Builder;
using Application.Order.ObserverDesign;
using Application.User.Builders;
using Domain.Notification.Interfaces;
using Domain.Notification.Services;
using Domain.Order.Services.Builder;
using Domain.Order.Services.ObserverDesign;
using Domain.User.Builders;
using Infrastructure.Communication.NotificationServices;
using Infrastructure.Order.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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
#endregion

// ??? CommandHandler (??????? ?? ???? ?????? ?? MediatR ????? ??????)
builder.Services.AddMediatR(typeof(SendNotificationCommandHandler));

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
