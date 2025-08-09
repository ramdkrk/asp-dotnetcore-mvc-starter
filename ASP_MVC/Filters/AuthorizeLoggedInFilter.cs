using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_MVC.Filters
{
    // Simple authorization filter ensuring user is authenticated
    public sealed class AuthorizeLoggedInFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity?.IsAuthenticated != true)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}



