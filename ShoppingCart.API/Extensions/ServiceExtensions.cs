using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShoppingCart.Contracts;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.Constants;
using ShoppingCart.Entities.Data;
using ShoppingCart.Repositories;
using ShoppingCart.Services;
using ShoppingCart.Services.LoggerService;
using System.Reflection;

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

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

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
                        RoleClaimType = "http://demozero.net/roles",
                        NameClaimType = "Roles",
                        ValidateLifetime = true,
                        ValidAudience = configuration["Auth0:Audience"],
                        ValidateAudience = true,
                        ValidIssuer = $"https://{configuration["Auth0:Domain"]}",
                        ValidateIssuer = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("FullAccess", policy => policy.RequireRole(UserRoles.Standard));
                options.AddPolicy("ReadAccess", policy => policy.RequireAssertion(ctx => ctx.User.IsInRole(UserRoles.Standard) || ctx.User.IsInRole(UserRoles.Viewer)));
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ShoppingCart API",
                    Version = "v1",
                    Description = "ShoppingCart API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer"
                        },
                        new List<string>()
                    }
                });

            });
        }
    }
}
