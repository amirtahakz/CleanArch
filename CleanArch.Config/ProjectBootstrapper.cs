﻿using CleanArch.Infrastructure.Persistent.Memory;
using CleanArch.Infrastructure.Persistent.Memory.Orders;
using CleanArch.Infrastructure.Persistent.Memory.Products;
using CleanArch.Application.Orders;
using CleanArch.Application.Products;
using CleanArch.Contracts;
using CleanArch.Domain.OrderAgg.Repository;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using CleanArch.Domain.OrderAgg.Services;
using CleanArch.Application.Orders.Services;
using MediatR;
using CleanArch.Application.Products.Create;

namespace CleanArch.Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderDomainService, OrderDomainService>();

            services.AddMediatR(typeof(CreateProductCommand));

            services.AddScoped<ISmsService, SmsService>();
            services.AddSingleton<Context>();
        }
    }
}