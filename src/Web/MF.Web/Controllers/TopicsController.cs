namespace MF.Web.Controllers
{
    using MF.Models.ViewModels.Reply;
    using MF.Models.ViewModels.Topic;
    using MF.Services.Categories;
    using MF.Services.Replies;
    using MF.Services.Topics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    public class TopicsController : BaseController
    {
        private readonly ITopicsService topicsService;
        private readonly ICategoriesService categoriesService;
        private readonly IRepliesService repliesService;

        public TopicsController(
            ITopicsService topicsService,
            ICategoriesService categoriesService,
            IRepliesService repliesService
            )
        {
            this.topicsService = topicsService;
            this.categoriesService = categoriesService;
            this.repliesService = repliesService;
        }

        public IActionResult All(int categoryId)
        {
            var categoryDetails = this.categoriesService.GetDetails(categoryId);
            var topics = this.topicsService.All(categoryId);
            categoryDetails.Topics = topics;

            return this.View(categoryDetails);
        }

        [Authorize]
        public IActionResult Create(int categoryId)
        {
            return this.View(new TopicCreateInputModel() { CategoryId = categoryId });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(TopicCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var userId = this.GetUserId();
            var topicId = this.topicsService.Create(input, userId);

            var replyInputModel = new ReplyCreateViewModel() { Content = input.Content, TopicId = topicId };
            this.repliesService.Create(replyInputModel, userId);

            return RedirectToAction(nameof(RepliesController.All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = topicId });
        }

        [Authorize]
        public IActionResult Delete (int topicId)
        {
            var isServiceMember = this.User.IsInRole(AdministratorRoleName) || this.User.IsInRole(ModeratorRoleName);
            this.topicsService.Delete(topicId);

            return this.RedirectToPreviousPage();
        }

        [Authorize]
        public IActionResult AddFollower(int topicId)
        {
            var userId = this.GetUserId();
            var isFollower = this.topicsService.IsFollower(userId, topicId);
            if (isFollower)
            {
                this.RedirectToAction(nameof(RepliesController.All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = topicId });
            }

            this.topicsService.AddFollower(userId, topicId);

            return this.RedirectToAction(nameof(RepliesController.All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = topicId });
        }

        [Authorize]
        public IActionResult RemoveFollower(int topicId)
        {
            var userId = this.GetUserId();
            var isFollower = this.topicsService.IsFollower(userId, topicId);
            if (!isFollower)
            {
                return this.RedirectToAction(nameof(RepliesController.All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = topicId });
            }

            this.topicsService.RemoveFollower(userId, topicId);

            return this.RedirectToAction(nameof(RepliesController.All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = topicId });
        }
    }
}
