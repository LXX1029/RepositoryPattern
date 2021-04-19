using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
            try
            {
                if (appContext.Database.GetPendingMigrations().Any())
                {
                    Console.WriteLine("==正在开始迁移数据库");
                    appContext.Database.Migrate();
                    Console.WriteLine("==迁移数据库完毕");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"迁移数据库出错：{ex}");
            }
            return host;
        }
    }
}
