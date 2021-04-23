using AspNetCore_NlogTest.Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly ILoggerManager _loggerManager;

        public ExceptionHandleMiddleware(RequestDelegate next, ILoggerManager loggerManager)
        {
            this._next = next;
            this._loggerManager = loggerManager;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                //context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _loggerManager.LogError($"Internal Server Error：{ex}");
                //_loggerManager.LogInfo(ex.Message);
                //_loggerManager.LogDebug(ex.Message);
                //_loggerManager.LogWarn(ex.Message);
                await context.Response.WriteAsync(new ResponseDetails
                {
                    Code = context.Response.StatusCode,
                    Message = "Internal Server Error"
                }.ToString());
            }
        }
    }
}
