using Micro.RabbitMQ.Banking.Api.Data.Context;
using Micro.RabbitMQ.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BankingContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SQL"),
            b => b.MigrationsAssembly("Micro.RabbitMQ.Banking.Data"));
    });

builder.Services.RegisterServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
