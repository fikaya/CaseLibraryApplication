using LibraryApplication.Entities.Constans;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryApplication.WebApp.Filters
{
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        //Action çalışmadan önce şunu yap demiş oldum.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetInt32(Constans.UserID).GetValueOrDefault() == 0)
            {
                context.Result = new RedirectToActionResult("SignIn", "Home", null);
            }
        }
    }
}
