using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalzadosLunghi.API.Middleware
{
    public class FeatureSwitchAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public FeatureSwitchAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration config)
        {
            //obtenemos el endpoint asociado a la request gracias al routing middleware
            //luego leemos la metadata para saber si tiene algun RouteAttribute
            var endpoint = httpContext.GetEndpoint()?
                .Metadata.GetMetadata<RouteAttribute>();
          
            if(endpoint != null)
            {
                var featureSwitch = config.GetSection("FeaturesSwitches")
                    .GetChildren().FirstOrDefault(x => x.Key.ToLower() == endpoint.Template.ToLower());

                if (featureSwitch != null && !bool.Parse(featureSwitch.Value))
                {
                    httpContext.SetEndpoint(new Endpoint(context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        return Task.CompletedTask;
                    },
                    EndpointMetadataCollection.Empty, "FeatureNotFound"));
                }
            }

            await _next(httpContext);
        }
    }
}
