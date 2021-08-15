namespace MF.Web.Areas.Administrator.Controllers
{

    using System;

    using MF.Services.Topics;
    using MF.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class TopicArchivesController : BaseController
    {
        private readonly ITopicsService topicService;

        public TopicArchivesController(ITopicsService topicService)
        {
            this.topicService = topicService;
        }

        public IActionResult All()
        {
            var viewModel = this.topicService.GetArchives();

            return this.View(viewModel);
        }

        public IActionResult Restore(int topicId)
        {
            this.topicService.Restore(topicId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int topicId)
        {
            this.topicService.Delete(topicId);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
