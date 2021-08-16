namespace MF.Web.Areas.Administrator.Controllers
{
    using System;

    using MF.Web.Controllers;

    using Microsoft.AspNetCore.Mvc;

    using static MF.Common.GlobalConstants;

    [Area(AdministratorRoleName)]
    public class UsersController : BaseController
    {
        public IActionResult Ban()
        {
            throw new NotImplementedException();
        }

        public IActionResult Unban()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
