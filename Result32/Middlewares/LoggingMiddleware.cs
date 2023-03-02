using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text;
using Result32.Repositories;
using Result32.Models.Db;

namespace Result32.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository requestRepository)
        {
            var newRequest = new Request
            {
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await requestRepository.AddRequest(newRequest);
            await _next.Invoke(context);
        }
    }
}