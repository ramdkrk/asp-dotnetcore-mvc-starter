using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_MVC.Filters
{
    // Simple output caching via Cache-Control headers
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class CacheResponseAttribute : Attribute, IAsyncActionFilter
    {
        public int DurationSeconds { get; }

        public CacheResponseAttribute(int durationSeconds)
        {
            DurationSeconds = durationSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executed = await next();
            if (executed.Result is ObjectResult or ViewResult or ContentResult)
            {
                context.HttpContext.Response.Headers["Cache-Control"] = $"public,max-age={DurationSeconds}";
            }
        }
    }
}



