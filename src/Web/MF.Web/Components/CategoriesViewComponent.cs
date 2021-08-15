namespace MF.Web.Components
{
    using System.Threading.Tasks;

    using MF.Services.Categories;

    using Microsoft.AspNetCore.Mvc;

    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
             var viewModel = this.categoriesService.GetAll();

             return this.View(viewModel);
        }
    }
}
