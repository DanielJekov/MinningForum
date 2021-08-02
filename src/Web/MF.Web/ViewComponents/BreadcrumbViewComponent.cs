namespace MF.Web.ViewComponents
{
    using System.Collections;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    public class BreadcrumbViewComponent : ViewComponent
    {
        public BreadcrumbViewComponent()
        {

        }

        public async Task InvokeAsync()
        {
            var path = this.Request.Path.ToString();

            var crumbs = path.Split('/', ' ').ToList();
            ;
        }
    }
}
