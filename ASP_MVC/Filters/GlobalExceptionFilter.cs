using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ASP_MVC.Filters
{
    // Global exception filter to log and return a friendly error view
    public sealed class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Unhandled exception occurred");

            var result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
            result.ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}



