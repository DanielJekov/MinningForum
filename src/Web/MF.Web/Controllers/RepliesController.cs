namespace MF.Web.Controllers
{
    using MF.Models.ViewModels.Reply;
    using MF.Services.Replies;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    public class RepliesController : BaseController
    {
        private readonly IRepliesService repliesService;

        public RepliesController(IRepliesService repliesService)
        {
            this.repliesService = repliesService;
        }

        public IActionResult All(int topicId)
        {
            var authorId = this.GetUserId();
            var replies = this.repliesService.RepliesByTopic(topicId, authorId);

            this.ViewBag.TopicId = topicId;
            this.ViewBag.UserId = authorId;

            return this.View(replies);
        }

        [Authorize]
        [HttpPost]
        public IActionResult All(ReplyCreateViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = input.TopicId });
            }

            var authorId = this.GetUserId();
            this.repliesService.Create(input, authorId);

            return this.RedirectToAction(nameof(All), nameof(RepliesController).Replace("Controller", string.Empty), new { topicId = input.TopicId });
        }

        [Authorize]
        //Have at least one bug: anyone can delete comment !!! have to put validation for user!!!!
        public IActionResult Delete(int replyId)
        {
            var isServiceMember = this.User.IsInRole(AdministratorRoleName);
            var userId = this.GetUserId();
            var isOwner = this.repliesService.IsOwner(userId, replyId);
            if (!(isOwner || isServiceMember))
            {
                return this.RedirectToPreviousPage();
            }

            this.repliesService.Delete(replyId);

            return this.RedirectToPreviousPage();
        }
    }
}
