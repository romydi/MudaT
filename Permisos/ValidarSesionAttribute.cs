using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MudarT.Extensions;

namespace MudarT.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext= context.HttpContext;
            if (httpContext.Session.GetObject<int>("Usuario") <= 0) {
                context.Result = new RedirectResult("~/Login/Login");
            }

            base.OnActionExecuting(context);
        }
    }
}
