namespace MF.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        public IActionResult Profile()
        {
            return this.View();
        }
    }
}
