using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CalzadosLunghi.API.Middleware
{
    public class FeaturesSwitchMiddleware
    {
        private readonly RequestDelegate _next;

        public FeaturesSwitchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration config)
        {
            if (context.Request.Path.Value.Contains("/features"))
            {
                var switches = config.GetSection("FeaturesSwitches");

                var report = switches.GetChildren().Select(x => $"{x.Key} : {x.Value }");

                await context.Response.WriteAsync(string.Join("\n", report));
            }
            else
            {
                await _next(context);
            }
        }
    }
}
