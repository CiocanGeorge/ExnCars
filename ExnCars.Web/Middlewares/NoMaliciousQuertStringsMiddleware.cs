using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExnCars.Web.Middlewares
{
    public class NoMaliciousQuertStringsMiddleware
    {
        private readonly RequestDelegate _next;
        public NoMaliciousQuertStringsMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.QueryString.Value.Contains("role=admin"))
            {
                context.Response.WriteAsync("UNAUTHORIZE!!!!");
                return;
            }
            await _next(context);
        }
    }
}
