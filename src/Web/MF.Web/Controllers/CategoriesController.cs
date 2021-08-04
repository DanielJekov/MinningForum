namespace MF.Web.Controllers
{
    using MF.Models.ViewModels.Category;
    using MF.Services.Categories;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
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

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToPreviousPage();
            }

            var authorId = this.GetUserId();
            this.categoriesService.Create(input, authorId);

            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int categoryId)
        {
            this.categoriesService.Delete(categoryId);

            return this.RedirectToAction(nameof(All));
        }
    }
}
