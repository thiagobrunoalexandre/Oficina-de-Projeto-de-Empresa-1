
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge
{
    public class AdminCredentialsFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
          /*  if (AdminCookieController.AdminID == 0)
            {
                context.Result = new RedirectToActionResult("Login", "Admin",null);
            }
            // Do something before the action executes.*/
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
