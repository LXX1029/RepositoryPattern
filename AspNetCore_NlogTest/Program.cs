//using Entities;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AspNetCore_NlogTest
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args)
//                .Build()
//                .MigrateDatabase()
//                .Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}

using AspNetCore_NlogTest.Extensions;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
// ����Json�ļ�
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true);
// ���ùܵ�����
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqliteContext(builder.Configuration);
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureRepositoryWrapper();

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddControllers();
var app = builder.Build();
app.MigrateDatabase();


// ����Http����ܵ�
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}
app.UseHttpsRedirection();
//app.UseStatusCodePages();
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".pdf"] = "application/pdf";
// ʹ���Զ����м��
app.UseCustomExceptionMiddleware();
app.UseStaticFiles();
app.UseDirectoryBrowser();

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        context.Response.ContentType = "application/json;chartset=utf-8";
        await context.Response.WriteAsync("����Ĭ�����");
    });

    endpoints.MapControllers();
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync($"Worker Process Name : {System.Diagnostics.Process.GetCurrentProcess().ProcessName}");
    });
});

app.Run();
