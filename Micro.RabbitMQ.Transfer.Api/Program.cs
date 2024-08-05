using Micro.RabbitMQ.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Micro.RabbitMQ.Infra.IoC;
using Micro.RabbitMQ.Banking.Application.Interfaces;
using Micro.RabbitMQ.Banking.Application.Services;
using Micro.RabbitMQ.Banking.Data.Repositories;
using Micro.RabbitMQ.Banking.Domain.Interfaces;
using Micro.RabbitMQ.Domain.Core.Bus;
using Micro.RabbitMQ.Infra.Bus;
using Micro.RabbitMQ.Transfer.Domain.Interfaces;
using Micro.RabbitMQ.Transfer.Data.Repositories;
using Micro.RabbitMQ.Transfer.Application.Interfaces;
using Micro.RabbitMQ.Transfer.Application.Services;
using Micro.RabbitMQ.Transfer.Domain.Events;
using Micro.RabbitMQ.Transfer.Domain.EventHandlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TransferContext>(
    options =>
    {
        options.UseSqlServer(
        builder.Configuration.GetConnectionString("TransferDbConnection"));
    });

//Domain bus

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(
        typeof(Micro.RabbitMQ.Transfer.Domain.Models.TransgerLogModel).Assembly));

builder.Services.AddScoped<ITransferLogRepository, TransgerLogRepository>();
builder.Services.AddScoped<ITransferService, TransferService>();
builder.Services.AddScoped<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();
builder.Services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
{
    var scope = sp.GetRequiredService<IServiceScopeFactory>();
    return new RabbitMQBus(sp.GetService<IMediator>(), scope);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


ConfigureEventBus(app);
void ConfigureEventBus(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var eventBus = scope.ServiceProvider.GetService<IEventBus>();
    eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
}


app.Run();
