namespace MF.Web
{
    using MF.Data;
    using MF.Data.Models;
    using MF.Data.Seeding;
    using MF.Services.Categories;
    using MF.Services.Messages;
    using MF.Services.Replies;
    using MF.Services.ReportReplies;
    using MF.Services.ReportTopics;
    using MF.Services.Topics;
    using MF.Services.Users;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MFDbContext>(options =>
                options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<MFUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<MFRole>().AddEntityFrameworkStores<MFDbContext>();

            services.Configure<CookiePolicyOptions>(
              options =>
              {
                  options.CheckConsentNeeded = context => true;
                  options.MinimumSameSitePolicy = SameSiteMode.None;
              });

            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                }).AddRazorRuntimeCompilation();

            services.AddSingleton(this.configuration);

            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<ITopicsService, TopicsService>();
            services.AddTransient<IRepliesService, RepliesService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IMessagesService, MessagesService>();
            services.AddTransient<ITopicReportsService, TopicReportsService>();
            services.AddTransient<IReplyReportsService, ReplyReportsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<MFDbContext>();
                dbContext.Database.Migrate();
                new MFDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Home/Error{0}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
