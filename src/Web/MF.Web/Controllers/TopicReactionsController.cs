namespace MF.Web.Controllers
{
    using MF.Data.Models.Enums;
    using MF.Services.Topics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TopicReactionsController : BaseController
    {
        private readonly ITopicsService topicsService;

        public TopicReactionsController(ITopicsService topicsService)
        {
            this.topicsService = topicsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Controller(int topicId, ReactionType reaction)
        {
            var userId = this.GetUserId();

            if (this.topicsService.IsReacted(userId, topicId))
            {
                if (this.topicsService.IsSameReaction(userId, topicId, reaction))
                {
                    return this.RedirectToAction(nameof(this.Remove), new { topicId });
                }
                else
                {
                    return this.RedirectToAction(
                                                 nameof(this.Change),
                                                 new { topicId, reaction });
                }
            }

            return this.RedirectToAction(nameof(this.Add), new { topicId, reaction });
        }

        [Authorize]
        public IActionResult Add(int topicId, ReactionType reaction)
        {
            var userId = this.GetUserId();
            this.topicsService.AddReaction(userId, topicId, reaction);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }

        [Authorize]
        public IActionResult Remove(int topicId)
        {
            var userId = this.GetUserId();
            this.topicsService.RemoveReaction(userId, topicId);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }

        [Authorize]
        public IActionResult Change(int topicId, ReactionType reaction)
        {
            var userId = this.GetUserId();
            this.topicsService.ChangeReaction(userId, topicId, reaction);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }
    }
}
