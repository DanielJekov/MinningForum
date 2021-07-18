namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TopicReportConfiguration : IEntityTypeConfiguration<TopicReport>
    {
        public void Configure(EntityTypeBuilder<TopicReport> topicReport)
        {
        }
    }
}
