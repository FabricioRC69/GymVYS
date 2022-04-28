using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymVidaYSaludWEB
{
  
        public class FiltroDeSesion : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                    
                if (context.HttpContext.Session.GetString("Rol") == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        Action = "LogIn",
                        Controller = "Usuario"
                    }));
                }
            }
        }
    
}
