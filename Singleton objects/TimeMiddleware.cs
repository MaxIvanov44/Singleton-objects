using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton_objects
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        TimeService _timeService;
        public TimerMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }

        public async Task Invoke(HttpContext context, TimeService timeService)
        {
            _timeService = timeService;
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"Текущее время: {_timeService?.GetTime()}");
        }
    }
}
