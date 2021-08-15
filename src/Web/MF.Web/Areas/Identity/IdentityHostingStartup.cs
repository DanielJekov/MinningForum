using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MF.Web.Areas.Identity.IdentityHostingStartup))]

namespace MF.Web.Areas.Identity
{
    using Microsoft.AspNetCore.Hosting;

    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
