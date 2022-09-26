using CleanArch.Contracts;
using CleanArch.Domain.OrderAgg.Repository;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CleanArch.Application.Products.Create;
using CleanArch.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CleanArch.Infrastructure.Persistent.Ef.Orders;
using CleanArch.Infrastructure.Persistent.Ef.Products;
using CleanArch.Query.Products.GetById;
using CleanArch.Application.Shared;
using FluentValidation;

namespace CleanArch.Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddMediatR(typeof(GetProductByIdQuery).Assembly);

            services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
            services.AddDbContext<ApplicationDbContext>(option => { 
                option.UseSqlServer(connectionString); 
            });

            services.AddScoped<ISmsService, SmsService>();

        }
    }
}