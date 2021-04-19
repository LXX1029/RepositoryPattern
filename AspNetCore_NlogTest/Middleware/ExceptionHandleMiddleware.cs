using AspNetCore_NlogTest.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest.Middleware
{
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
                _loggerManager.LogError(ex.Message);
                //_loggerManager.LogInfo(ex.Message);
                //_loggerManager.LogDebug(ex.Message);
                //_loggerManager.LogWarn(ex.Message);
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
