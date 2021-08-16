namespace MF.Web.Areas
{
    using MF.Models.ViewModels.Categories;
    using MF.Services.Categories;
    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    [Area(AdministratorRoleName)]
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult All()
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            var viewModel = this.categoriesService.GetAll(false);
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateInputModel input)
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalMessageFailure] = this.ModelStateErrorCollector();

                return this.RedirectToAction(nameof(this.Create));
            }

            var authorId = this.GetUserId();
            this.categoriesService.Create(input, authorId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(CategoryEditViewModel model)
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditInputModel input)
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalMessageFailure] = this.ModelStateErrorCollector();

                return this.RedirectToAction(nameof(this.All));
            }

            this.categoriesService.Edit(input);

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            this.categoriesService.Archivate(categoryId);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
