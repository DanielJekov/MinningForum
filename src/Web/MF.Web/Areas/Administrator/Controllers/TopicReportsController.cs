namespace MF.Web.Areas.Administrator.Controllers
{
    using System;

    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    [Area(AdministratorRoleName)]
    public class TopicReportsController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
