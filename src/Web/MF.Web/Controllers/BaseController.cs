namespace MF.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseController : Controller
    {
        public string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public RedirectResult RedirectToPreviousPage()
        {
            string prevPage = this.Request.Headers["Referer"].ToString();
            return this.Redirect(prevPage);
        }
    }
}
