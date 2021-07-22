namespace MF.Web.Controllers
{
    using System.Security.Claims;

    using MF.Models.ViewModels;
    using MF.Services;

    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult All()
        {
            var categories = this.categoriesService.All();
            return this.View(categories);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.categoriesService.CreateCategory(input, authorId);

            return this.Redirect("All");
        }
    }
}
