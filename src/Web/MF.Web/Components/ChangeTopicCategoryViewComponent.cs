namespace MF.Web.Components
{
    using System.Threading.Tasks;

    using MF.Models.ViewModels.Topics;
    using MF.Services.Categories;

    using Microsoft.AspNetCore.Mvc;

    public class ChangeTopicCategoryViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public ChangeTopicCategoryViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int topicId)
        {
            var categories = this.categoriesService.GetAll(false);
            var viewModel = new ChangeCategoryOnTopicViewModel()
            {
                TopicId = topicId,
                Categories = categories,
            };

            return this.View(viewModel);
        }
    }
}
