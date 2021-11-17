using AspNetCore_NlogTest.Contracts;
using Domain.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence5Dot0;
using Persistence5Dot0.Repositories;
using Services;
using Services.Abstractions;

namespace AspNetCore_NlogTest.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSqlserverContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("sqlConnection");
            //services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, options =>
            //{
            //    options.EnableRetryOnFailure();
            //    options.MigrationsAssembly("AspNetCore_NlogTest");

            //}).ReplaceService<IQueryTranslationPostprocessorFactory, SqlServer2008QueryTranslationPostprocessorFactory>());
        }

        public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqliteConnection");
            services.AddDbContextPool<RepositoryContext>(options =>
            options.EnableSensitiveDataLogging()
            .UseSqlite(connectionString, options =>
            {

                options.MigrationsAssembly("Persistence5Dot0");
            }));
            ;
        }


        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
