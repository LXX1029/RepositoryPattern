using AspNetCore_NlogTest.Contracts;
using Domain.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Persistence5Dot0;
using Persistence5Dot0.Repositories;
using Services;
using Services.Abstractions;

namespace AspNetCore_NlogTest.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 配置日志服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            // 添加自定义服务
            services.AddSingleton<ILoggerManager, LoggerManager>();
            // 添加NLog服务
            services.AddLogging(options =>
            {
                //options.AddDebug();
                options.ClearProviders();
                options.AddNLog();
            });
        }
        /// <summary>
        ///  配置Sqlserver 数据库
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void ConfigureSqlserverContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<RepositoryContext>(options => options
            .EnableSensitiveDataLogging()
            .UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure();
                options.MigrationsAssembly("Persistence5Dot0");
            }));
        }
        /// <summary>
        ///  配置Sqlite 数据库
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqliteConnection");
            services.AddDbContextPool<RepositoryContext>(options =>
            options.EnableSensitiveDataLogging()
            .UseSqlite(connectionString, options =>
            {
                options.MigrationsAssembly("Persistence5Dot0");
            }));
        }


        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }
        /// <summary>
        /// 跨域服务
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });
        }
        /// <summary>
        /// 数据层服务
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
