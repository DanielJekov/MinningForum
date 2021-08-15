namespace MF.Web.Controllers.ReplyReports
{
    using MF.Models.ViewModels.ReplyReports;
    using MF.Services.Replies;
    using MF.Services.ReportReplies;
    using MF.Services.Topics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    public class ReplyReportsController : BaseController
    {
        private readonly IReplyReportsService reportRepliesService;
        private readonly ITopicsService topicsService;
        private readonly IRepliesService repliesService;

        public ReplyReportsController(
                                      IReplyReportsService reportRepliesService,
                                      ITopicsService topicsService,
                                      IRepliesService repliesService)
        {
            this.reportRepliesService = reportRepliesService;
            this.topicsService = topicsService;
            this.repliesService = repliesService;
        }

        [Authorize]
        public IActionResult Create(int replyId)
        {
            var isExist = this.repliesService.IsExist(replyId);
            if (!isExist)
            {
                return this.BadRequest();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ReplyReportCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalMessageFailure] = this.ModelStateErrorCollector();
                return this.Redirect("/");
            }

            var isExist = this.repliesService.IsExist(input.ReplyId.Value);
            if (!isExist)
            {
                return this.BadRequest();
            }

            var topicId = this.topicsService.GetIdByReplyId(input.ReplyId.Value);

            return this.RedirectToAction(
                                         nameof(RepliesController.All),
                                         nameof(RepliesController).Replace("Controller", string.Empty),
                                         new { topicId });
        }
    }
}
