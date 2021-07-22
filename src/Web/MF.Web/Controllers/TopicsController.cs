namespace MF.Web.Controllers
{
    using System.Security.Claims;

    using MF.Models.ViewModels;
    using MF.Services;

    using Microsoft.AspNetCore.Mvc;

    public class TopicsController : Controller
    {
        private readonly ITopicsService topicsService;

        public TopicsController(ITopicsService topicsService)
        {
            this.topicsService = topicsService;
        }

        public IActionResult All(int Id)
        {
            var topics = topicsService.All(Id);

            return this.View(topics);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(TopicCreateViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.topicsService.CreateTopic(input, authorId);

            return this.Redirect("All");
        }
    }
}
