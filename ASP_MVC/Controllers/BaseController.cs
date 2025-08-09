using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ILogger Logger { get; }

        protected BaseController(ILogger logger)
        {
            Logger = logger;
        }

        protected IActionResult SafeRedirectToAction(string action, string controller)
        {
            return RedirectToAction(action, controller);
        }
    }
}



