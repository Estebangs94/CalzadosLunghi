using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CalzadosLunghi.API.ActionFilter
{
    public class MobileActionFilter : Attribute, IActionFilter
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        //se ejecuta una vez que termino la ejecución normal de un Action method
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action executed");
        }

        //se ejecuta justo antes que el action method
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Request.Headers.ContainsKey("x-mobile"))
            {
                context.Result = new RedirectToActionResult(Action, Controller, null);
            }
        }
    }
}
