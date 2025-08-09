using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ASP_MVC.Filters
{
    // Logs action execution time and basic request info
    public sealed class RequestLoggingActionFilter : IActionFilter
    {
        private readonly ILogger<RequestLoggingActionFilter> _logger;
        private readonly Stopwatch _stopwatch = new();

        public RequestLoggingActionFilter(ILogger<RequestLoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Restart();
            var route = context.ActionDescriptor.DisplayName;
            _logger.LogInformation("Handling request for {Route}", route);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var route = context.ActionDescriptor.DisplayName;
            _logger.LogInformation("Handled request for {Route} in {ElapsedMs} ms", route, _stopwatch.ElapsedMilliseconds);
        }
    }
}



