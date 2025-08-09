using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace ASP_MVC.Filters
{
    // Enforces HTTPS in non-development environments
    public sealed class RequireHttpsPermanentFilter : IAuthorizationFilter
    {
        private readonly IHostEnvironment _environment;
        public RequireHttpsPermanentFilter(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_environment.IsDevelopment())
            {
                return;
            }

            var request = context.HttpContext.Request;
            if (!request.IsHttps)
            {
                var httpsUrl = "https://" + request.Host + request.Path + request.QueryString;
                context.Result = new RedirectResult(httpsUrl, permanent: true);
            }
        }
    }
}



