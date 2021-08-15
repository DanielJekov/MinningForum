namespace MF.Web.Controllers
{
    using System;

    using MF.Data.Models.Enums;
    using MF.Services.Replies;
    using MF.Services.Topics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReplyReactionsController : BaseController
    {
        private readonly IRepliesService repliesService;
        private readonly ITopicsService topicsService;

        public ReplyReactionsController(
                                        IRepliesService repliesService,
                                        ITopicsService topicsService)
        {
            this.repliesService = repliesService;
            this.topicsService = topicsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Controller(int replyId, string reactionName)
        {
            if (replyId == 0 || reactionName == string.Empty)
            {
                return this.RedirectToPreviousPage();
            }

            var isValidReaction = Enum.TryParse<ReactionType>(reactionName, out ReactionType reaction);
            var topicId = this.topicsService.GetIdByReplyId(replyId);

            if (!isValidReaction)
            {
                return this.RedirectToAction(
                                             nameof(RepliesController.All),
                                             nameof(RepliesController).Replace("Controller", string.Empty),
                                             new { topicId });
            }

            var userId = this.GetUserId();

            if (this.repliesService.IsReacted(userId, replyId))
            {
                if (this.repliesService.IsSameReaction(userId, replyId, reaction))
                {
                    this.repliesService.RemoveReaction(userId, replyId);
                }
                else
                {
                    this.repliesService.ChangeReaction(userId, replyId, reaction);
                }
            }

            this.repliesService.AddReaction(userId, replyId, reaction);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }
    }
}
