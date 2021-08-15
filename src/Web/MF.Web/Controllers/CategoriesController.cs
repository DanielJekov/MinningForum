namespace MF.Web.Controllers
{
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

        [HttpPost]
        [Authorize]
        public IActionResult Follow(int categoryId)
        {
            var isExist = this.categoriesService.IsExist(categoryId);
            if (isExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var isFollower = this.categoriesService.IsFollower(userId, categoryId);

            if (isFollower)
            {
                return this.BadRequest();
            }

            this.categoriesService.AddFollower(categoryId, userId);

            return this.RedirectToAction(
                                         nameof(TopicsController.All),
                                         nameof(TopicsController).Replace("Controller", string.Empty),
                                         new { categoryId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Unfollow(int categoryId)
        {
            var isExist = this.categoriesService.IsExist(categoryId);
            if (isExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var isFollower = this.categoriesService.IsFollower(userId, categoryId);

            if (!isFollower)
            {
                return this.BadRequest();
            }

            this.categoriesService.RemoveFollower(categoryId, userId);

            return this.RedirectToAction(
                                         nameof(TopicsController.All),
                                         nameof(TopicsController).Replace("Controller", string.Empty),
                                         new { categoryId });
        }
    }
}
