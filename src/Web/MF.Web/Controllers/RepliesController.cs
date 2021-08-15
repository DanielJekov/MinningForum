namespace MF.Web.Controllers
{
    using MF.Models.ViewModels.Replies;
    using MF.Services.Replies;
    using MF.Services.Topics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    public class RepliesController : BaseController
    {
        private readonly IRepliesService repliesService;
        private readonly ITopicsService topicsService;

        public RepliesController(
                                 IRepliesService repliesService,
                                 ITopicsService topicsService)
        {
            this.repliesService = repliesService;
            this.topicsService = topicsService;
        }

        public IActionResult All(int topicId)
        {
            var isTopicExist = this.topicsService.IsExist(topicId);
            if (!isTopicExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var viewModel = this.topicsService.GetDetails(topicId, userId);

            viewModel.Replies = this.repliesService.GetRepliesByTopic(topicId, userId);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ReplyCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalMessageFailure] = this.ModelStateErrorCollector();
                return this.RedirectToAction(nameof(this.All), new { topicId = input.TopicId });
            }

            var isQuoteReplyExist = this.repliesService.IsExist(input.QuoteReplyId.Value);

            if (!isQuoteReplyExist)
            {
                input.QuoteReplyId = null;
            }

            var authorId = this.GetUserId();
            this.repliesService.Create(input, authorId);

            return this.RedirectToAction(
                                         nameof(this.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId = input.TopicId },
                                         "Reply");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int replyId)
        {
            var isReplyExist = this.repliesService.IsExist(replyId);
            if (!isReplyExist)
            {
                return this.BadRequest();
            }

            var userId = this.GetUserId();
            var isOwner = this.repliesService.IsOwner(userId, replyId);
            var topicId = this.topicsService.GetIdByReplyId(replyId);
            if (!isOwner && !this.User.IsInRole(AdministratorRoleName))
            {
                return this.BadRequest();
            }

            this.repliesService.Delete(replyId);

            return this.RedirectToAction(nameof(this.All), new { topicId });
        }
    }
}
