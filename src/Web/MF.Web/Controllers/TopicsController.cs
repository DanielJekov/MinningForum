namespace MF.Web.Controllers
{
    using System.Security.Claims;

    using MF.Models.ViewModels;
    using MF.Services;

    using Microsoft.AspNetCore.Mvc;

    public class TopicsController : Controller
    {
        private readonly ITopicsService topicsService;
        private readonly ICategoriesService categoriesService;

        public TopicsController(
            ITopicsService topicsService,
            ICategoriesService categoriesService
            )
        {
            this.topicsService = topicsService;
            this.categoriesService = categoriesService;
        }

        [Route("Category/{CategoryId}/Topics")]
        public IActionResult TopicsByCategoryId(int categoryId)
        {
            var topics = this.topicsService.All(categoryId);

            this.ViewBag.CategoryId = categoryId;
            return this.View(topics);
        }

        [Route("Category/{CategoryId}/Topic/Create")]
        public IActionResult Create(int categoryId)
        {
            return this.View(categoryId);
        }

        [HttpPost("Category/{CategoryId}/Topic/Create")]
        public IActionResult Create(TopicCreateViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("Create");
            }

            var authorId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var topicId = this.topicsService.CreateTopic(input, authorId);

            return this.Redirect(topicId.ToString() + "/");
        }
    }
}
