namespace MF.Web.Areas.Administrator.Controllers
{
    using MF.Models.ViewModels.Topics;
    using MF.Services.Topics;
    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    [Area(AdministratorRoleName)]
    public class TopicsController : BaseController
    {
        private readonly ITopicsService topicsService;

        public TopicsController(ITopicsService topicsService)
        {
            this.topicsService = topicsService;
        }

        public IActionResult ChangeCategory(ChangeCategoryOnTopicInputModel input)
        {
            if (!this.User.IsInRole(AdministratorRoleName))
            {
                return this.Redirect("/");
            }

            this.topicsService.ChangeCategoryOnGivenTopic(input);

            return this.RedirectToPreviousPage();
        }
    }
}
