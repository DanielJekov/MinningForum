namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReplyReportConfiguration : IEntityTypeConfiguration<ReplyReport>
    {
        public void Configure(EntityTypeBuilder<ReplyReport> replyReport)
        {
        }
    }
}
