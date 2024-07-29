﻿using Micro.RabbitMQ.Banking.Api.Data.Context;
using Micro.RabbitMQ.Banking.Application.Interfaces;
using Micro.RabbitMQ.Banking.Application.Services;
using Micro.RabbitMQ.Banking.Data.Repositories;
using Micro.RabbitMQ.Banking.Domain.Interfaces;
using Micro.RabbitMQ.Domain.Core.Bus;
using Micro.RabbitMQ.Domain.Core.Events;
using Micro.RabbitMQ.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.RabbitMQ.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices( this IServiceCollection services)
        {

            
            //Domain bus
            services.AddScoped<IEventBus, RabbitMQBus>();

            //application service
            services.AddScoped<IAccountService, AccountService>();

            //domain data
            services.AddScoped<IAccountRepository, AccountRepository>();

            //services.AddTransient<BankingContext>();
        }
    }
}
