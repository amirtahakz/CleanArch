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
using CleanArch.Query.Models;
using MongoDB.Driver;
using CleanArch.Query.Models.Products.Repository;
using CleanArch.Domain.UserAgg.Repository;
using CleanArch.Infrastructure.Persistent.Ef.Users;
using CleanArch.Application.Users.Register;
using CleanArch.Domain.UserAgg.Services;
using CleanArch.Application.Users;
using CleanArch.Query.Users.GetByEmail;
using CleanArch.Query.Models.Users.Repository;

namespace CleanArch.Config
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection services , string connectionString)
        {
            //Repositories
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserDomainService, UserDomainService>();



            ///
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));



            //
            services.AddMediatR(typeof(CreateProductCommand).Assembly);
            services.AddMediatR(typeof(GetProductByIdQuery).Assembly);
            //services.AddMediatR(typeof(GetByEmailQuery).Assembly);



            //Validators
            services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);



            //For query layer for mongoDb reader
            services.AddTransient<IProductReadRepository, ProductReadRepository>();
            services.AddTransient<IUserReadRepository, UserReadRepository>();



            //DataBases
            services.AddDbContext<ApplicationDbContext>(option => { 
                option.UseSqlServer(connectionString); 
            });
            services.AddSingleton<IMongoClient, MongoClient>(services =>
            {
                return new MongoClient("mongodb://localhost:27017");
            });


            //Contract layer
            services.AddScoped<ISmsService, SmsService>();

        }
    }
}