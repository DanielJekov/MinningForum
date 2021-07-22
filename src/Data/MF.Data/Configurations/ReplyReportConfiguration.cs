namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReplyReportConfiguration : IEntityTypeConfiguration<ReplyReport>
    {
        public void Configure(EntityTypeBuilder<ReplyReport> replyReport)
        {

            replyReport
                       .HasOne(r => r.ReportProcessData)
                       .WithMany(c => c.ReplyReports)
                       .OnDelete(DeleteBehavior.Restrict);

            replyReport
                       .HasOne(c => c.Reply)
                       .WithMany(c => c.ReplyReports)
                       .OnDelete(DeleteBehavior.Restrict);

            replyReport
                       .HasOne(c => c.ReportingUser)
                       .WithMany(c => c.ReplyReports)
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
