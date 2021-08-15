namespace MF.Web.Controllers
{
    using MF.Models.ViewModels.Replies;
    using MF.Models.ViewModels.Topics;
    using MF.Services.Categories;
    using MF.Services.Replies;
    using MF.Services.Topics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    public class TopicsController : BaseController
    {
        private readonly IRepliesService repliesService;
        private readonly ITopicsService topicsService;
        private readonly ICategoriesService categoriesService;

        public TopicsController(
                                IRepliesService repliesService,
                                ITopicsService topicsService,
                                ICategoriesService categoriesService)
        {
            this.repliesService = repliesService;
            this.topicsService = topicsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult All(int categoryId)
        {
            var isCategoryExist = this.categoriesService.IsExist(categoryId);
            if (!isCategoryExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var viewModel = this.categoriesService.GetDetails(userId, categoryId);
            viewModel.Topics = this.topicsService.GetTopicsByCategory(categoryId);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create(int categoryId)
        {
            var isCategoryExist = this.categoriesService.IsExist(categoryId);
            if (!isCategoryExist)
            {
                return this.BadRequest();
            }

            return this.View(new TopicCreateInputModel() { CategoryId = categoryId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(TopicCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalMessageFailure] = this.ModelStateErrorCollector();
                return this.Redirect("/");
            }

            var isCategoryExist = this.categoriesService.IsExist(input.CategoryId.Value);
            if (!isCategoryExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var topicId = this.topicsService.Create(input, userId);

            var replyInputModel = new ReplyCreateInputModel() { Content = input.Content, TopicId = topicId };
            this.repliesService.Create(replyInputModel, userId);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int topicId)
        {
            var isExist = this.topicsService.IsExist(topicId);
            if (!isExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var isUserOwner = this.topicsService.IsOwner(userId, topicId);
            if (!isUserOwner && !this.User.IsInRole(AdministratorRoleName))
            {
                return this.BadRequest();
            }

            this.topicsService.Delete(topicId);

            var categoryId = this.categoriesService.GetIdByTopicId(topicId);
            return this.RedirectToAction(nameof(this.All), new { categoryId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Follow(int topicId)
        {
            var isTopicExist = this.topicsService.IsExist(topicId);

            if (!isTopicExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var isFollower = this.topicsService.IsFollower(userId, topicId);
            if (isFollower)
            {
                return this.BadRequest();
            }

            this.topicsService.AddFollower(userId, topicId);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Unfollow(int topicId)
        {
            var isTopicExist = this.topicsService.IsExist(topicId);
            if (!isTopicExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var isFollower = this.topicsService.IsFollower(userId, topicId);
            if (!isFollower)
            {
                return this.RedirectToAction(
                                             nameof(RepliesController.All),
                                             nameof(RepliesController).Replace("Controller", string.Empty),
                                             new { topicId });
            }

            this.topicsService.RemoveFollower(userId, topicId);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }
    }
}
