using AspNetCore_NlogTest.Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest.Middleware
{
    /// <summary>
    /// 自定义异常处理中间件
    /// </summary>
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandleMiddleware> _logger;
        private readonly ILoggerManager _loggerManager;

        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger, ILoggerManager loggerManager, RequestDelegate next)
        {
            this._next = next;
            this._logger = logger;
            this._loggerManager = loggerManager;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                this._logger.LogInformation("ExceptionHandle Middleware Invoke");

                if (context.Response.StatusCode == 404)
                {
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(new ResponseDetails
                    {
                        ResponseCode = ResponseCode.NotFound,
                        Message = $"无法找到请求地址"
                    }.ToString());
                }

            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Internal Server Error：{ex}");
                //this._loggerManager.LogError(ex);
                await context.Response.WriteAsync(new ResponseDetails
                {
                    ResponseCode = ResponseCode.InnterServerError,
                    Message = $"Internal Server Error:{ex.Message}"
                }.ToString());
            }
        }
    }
}
