namespace MF.Data
{
    using MF.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class MFDbContext : IdentityDbContext<MFUser, MFRole, string>
    {
        public MFDbContext(DbContextOptions<MFDbContext> options)
            : base(options)
        {
        }

        public DbSet<MFUser> MFUsers { get; set; }

        public DbSet<MFRole> MFRoles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<TopicReaction> TopicReactions { get; set; }

        public DbSet<TopicReport> TopicReports { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<ReplyReaction> ReplyReactions { get; set; }

        public DbSet<ReplyReport> ReplyReports { get; set; }

        public DbSet<BanData> BansData { get; set; }

        public DbSet<ReportProcessData> ReportsProcessData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
