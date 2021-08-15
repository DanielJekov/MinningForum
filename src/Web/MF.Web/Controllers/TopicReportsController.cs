namespace MF.Web.Controllers
{
    using MF.Models.ViewModels.TopicReports;
    using MF.Services.ReportTopics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    public class TopicReportsController : BaseController
    {
        private readonly ITopicReportsService topicReportsService;

        public TopicReportsController(ITopicReportsService topicReportsService)
        {
            this.topicReportsService = topicReportsService;
        }

        [Authorize]
        public IActionResult Create(TopicReportViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(TopicReportCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData[GlobalMessageFailure] = this.ModelStateErrorCollector();
                return this.Redirect("/");
            }

            this.TempData[GlobalMessageSuccess] = "The report has been successfull send to administators.";
            return this.Redirect("/");
        }
    }
}
