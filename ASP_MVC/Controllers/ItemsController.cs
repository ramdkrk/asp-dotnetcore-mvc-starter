using System.Threading.Tasks;
using ASP_MVC.Services;
using ASP_MVC.ViewModels.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_MVC.Controllers
{
    public sealed class ItemsController : BaseController
    {
        private readonly IExampleService _exampleService;

        public ItemsController(ILogger<ItemsController> logger, IExampleService exampleService)
            : base(logger)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        [ASP_MVC.Filters.CacheResponse(60)]
        public async Task<IActionResult> Index()
        {
            var items = await _exampleService.GetItemsAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ItemViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["Message"] = $"Created: {model.Name}";
            return SafeRedirectToAction("Index", "Items");
        }
    }
}


