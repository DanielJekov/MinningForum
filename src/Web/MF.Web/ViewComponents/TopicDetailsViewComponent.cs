namespace MF.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MF.Services;
    using MF.Services.Topics;
    using Microsoft.AspNetCore.Mvc;

    public class TopicDetailsViewComponent : ViewComponent
    {
        private readonly ITopicsService topicsService;

        public TopicDetailsViewComponent(ITopicsService topicsService)
        {
            this.topicsService = topicsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int topicId)
        {
            return null;
        }
    }
}
