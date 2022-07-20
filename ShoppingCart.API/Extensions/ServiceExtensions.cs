﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Contracts;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.Data;
using ShoppingCart.Repositories;
using ShoppingCart.Services;
using ShoppingCart.Services.LoggerService;

namespace ShoppingCart.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ShoppingCart"),
            b => b.MigrationsAssembly("ShoppingCart.API")));
        }

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureAuhtentification(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://{configuration["Auth0:Domain"]}";
                options.Audience = configuration["Auth0:Audience"];

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = "http://demozero.net/roles"
                };
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("FullAccess", policy => policy.RequireRole("Standard"));
                options.AddPolicy("ReadAccess", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole("Standard") || ctx.User.IsInRole("Viewer")));
            });
        }
    }
}
