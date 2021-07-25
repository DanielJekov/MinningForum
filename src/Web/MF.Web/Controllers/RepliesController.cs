namespace MF.Web.Controllers
{
    using System.Security.Claims;

    using MF.Models.ViewModels;
    using MF.Services;

    using Microsoft.AspNetCore.Mvc;

    public class RepliesController : Controller
    {
        private readonly IRepliesService repliesService;

        public RepliesController(IRepliesService repliesService)
        {
            this.repliesService = repliesService;
        }

        [Route("Category/{CategoryId}/Topic/{TopicId}")]
        public IActionResult RepliesByTopicId(int topicId)
        {
            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var replies = this.repliesService.RepliesByTopicId(topicId, authorId);
            this.ViewBag.TopicId = topicId;

            return this.View(replies);
        }

        [Route("Category/{CategoryId}/Topic/{TopicId}/Answer")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("Category/{CategoryId}/Topic/{TopicId}")]
        public IActionResult Createe(ReplyCreateViewModel input, int categoryId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Answer");
            }

            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.repliesService.CreateReply(input, authorId);

            //Have to found better way to this reddirect
            return this.Redirect("/Category/" + categoryId.ToString() + "/Topic/" + input.TopicId.ToString() + "/");
        }

        //Have at least one bug: anyone can delete comment !!! have to put validation for user!!!!
        [Route("Category/{categoryId}/Topic/{TopicId}/Reply/Delete/{ReplyId}")]
        public IActionResult DeleteTopicById(int categoryId, int topicId, int replyId)
        {
            this.repliesService.DeleteReply(replyId);

            return this.Redirect("/Category/" + categoryId.ToString() + "/Topic/" + topicId.ToString() + "/");
        }
    }
}
