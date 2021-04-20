using AspNetCore_NlogTest.Contracts;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //var connectionString = configuration["SqlserverConnection:ConnectionStrings"];
            //var conn1 = configuration.GetValue<string>("ConnectionStrings:sqlConnection");
            var connectionString = configuration.GetConnectionString("sqlConnection");

            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure();
                options.MigrationsAssembly("AspNetCore_NlogTest");

            }).ReplaceService<IQueryTranslationPostprocessorFactory, SqlServer2008QueryTranslationPostprocessorFactory>());
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

        public static void ConfigureRepositoryWrapper(this IServiceCollection services) => services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}
