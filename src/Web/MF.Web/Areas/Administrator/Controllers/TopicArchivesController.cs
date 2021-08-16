namespace MF.Web.Areas.Administrator.Controllers
{
    using MF.Services.Topics;
    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    [Area(AdministratorRoleName)]
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
