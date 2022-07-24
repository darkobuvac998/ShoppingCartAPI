using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Contracts;
using ShoppingCart.Entities.Data;
using ShoppingCart.IntegrationTests.AuthTests;
using System;
using System.IO;
using System.Linq;

namespace ShoppingCart.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public string? UserRole { get; set; }

        private IConfiguration Configuration
        {
            get
            {
                return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.tests.json").Build();
            }
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                var conf = new ConfigurationBuilder().AddJsonFile("appsettings.tests.json").Build();

                config.AddConfiguration(conf);
            });

            builder.ConfigureTestServices(services =>
            {
                services.Configure<TestAuthHandlerOptions>(options => options.UserRole = UserRole);

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = TestAuthHandler.AuthenticationScheme;
                    options.DefaultScheme = TestAuthHandler.AuthenticationScheme;
                }).AddScheme<TestAuthHandlerOptions, TestAuthHandler>(TestAuthHandler.AuthenticationScheme, options => { });
            });

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ShoppingCartDatabaseContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ShoppingCartDatabaseContext>((options, context) =>
                {
                    context.UseSqlServer(Configuration.GetConnectionString("ShoppingCartTest"));
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedService = scope.ServiceProvider;
                    var db = scopedService.GetRequiredService<ShoppingCartDatabaseContext>();
                    var logger = scopedService.GetRequiredService<ILoggerManager>();

                    try
                    {
                        db.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError($"TIME: {DateTime.Now}");
                        logger.LogError($"An error occurred {ex.Message}.");
                    }
                }
            });
        }

    }
}
