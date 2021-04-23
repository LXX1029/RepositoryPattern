using AspNetCore_NlogTest.Contracts;
using AspNetCore_NlogTest.Middleware;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// UseExceptionHandler 扩展
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        /// <param name="logger">ILoggerManager</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager _loggerManager)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        _loggerManager.LogError($"Internal Server Error：{contextFeature.Error}");
                        // 返回错误、根据需要自定义返回数据格式
                        //await context.Response.WriteAsync(new ErrorDetails()
                        //{
                        //    StatusCode = context.Response.StatusCode,
                        //    Message = "Internal Server Error"
                        //}.ToString());
                        await context.Response.WriteAsync(new ResponseDetails
                        {
                            Code = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }

        /// <summary>
        /// 自定义异常处理中间件
        /// </summary>
        /// <param name="app">IApplicationBuilder</param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}
