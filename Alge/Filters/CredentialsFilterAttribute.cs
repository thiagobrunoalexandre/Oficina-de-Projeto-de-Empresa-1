using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge
{
    public class CredentialsFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (AlgeCookieController.UserStatus == null)
            {
                string controller = (string)context.RouteData.Values["Controller"];
                string action = (string)context.RouteData.Values["Action"];
                context.Result = new RedirectToActionResult("Login", "Home", new { redirectUrl = AppHttpContext.Url });
            }
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
