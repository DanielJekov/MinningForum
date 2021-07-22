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

        public IActionResult All(int Id)
        {
            var replies = repliesService.All(Id);

            return this.View(replies);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ReplyCreateViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.repliesService.CreateReply(input, authorId);

            return this.Redirect("All");
        }
    }
}
