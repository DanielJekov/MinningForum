namespace MF.Web.Controllers
{
    using System.Diagnostics;

    using MF.Models.ViewModels;
    using MF.Services.Categories;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
                              ILogger<HomeController> logger,
                              ICategoriesService categoriesService)
        {
            this._logger = logger;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Error404()
        {
            return this.View();
        }
    }
}
