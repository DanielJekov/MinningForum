namespace MF.Web.Areas.Administrator.Controllers
{
    using MF.Services.Replies;
    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    [Area(AdministratorRoleName)]
    public class ReplyArchivesController : BaseController
    {
        private readonly IRepliesService repliesService;

        public ReplyArchivesController(IRepliesService repliesService)
        {
            this.repliesService = repliesService;
        }

        public IActionResult All()
        {
            var viewModel = this.repliesService.GetArchives();

            return this.View(viewModel);
        }

        public IActionResult Restore(int replyId)
        {
            this.repliesService.Restore(replyId);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int replyId)
        {
            this.repliesService.Delete(replyId);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
