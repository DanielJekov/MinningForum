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

        [Route("/Categories")]
        public IActionResult All()
        {
            var categories = this.categoriesService.All();
            return this.View(categories);
        }

        [Route("/Category/Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("/Category/Create")]
        public IActionResult Create(CategoryCreateViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.categoriesService.CreateCategory(input, authorId);

            return this.Redirect("/Categories");
        }

        [Route("Category/Delete/{CategoryId}")]
        public IActionResult DeleteCategoryById(int categoryId)
        {
            this.categoriesService.DeleteCategory(categoryId);

            return this.Redirect("/Categories");
        }
    }
}
