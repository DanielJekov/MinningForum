namespace MF.Web.Areas.Administrator.Controllers
{
    using System;

    using MF.Services.Categories;
    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    public class CategoryArchivesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoryArchivesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult All()
        {
            var viewModel = this.categoriesService.GetArchives();

            return this.View(viewModel);
        }

        public IActionResult Restore(int categoryId)
        {
            this.categoriesService.Restore(categoryId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int categoryId)
        {
            this.categoriesService.Delete(categoryId);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
