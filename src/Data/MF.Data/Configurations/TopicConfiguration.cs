namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> topic)
        {
            topic
                .HasOne(t => t.Author)
                .WithMany(t => t.Topics)
                .OnDelete(DeleteBehavior.SetNull);

            //topic
            //    .HasOne(t => t.Category)
            //    .WithMany(t => t.Topics)
            //    .OnDelete(DeleteBehavior.SetNull);

            topic
                .HasMany(t => t.Replies)
                .WithOne(t => t.Topic)
                .OnDelete(DeleteBehavior.Cascade);

            topic
                .HasMany(t => t.TopicReactions)
                .WithOne(t => t.Topic)
                .OnDelete(DeleteBehavior.Cascade);

            topic
                .HasMany(t => t.TopicReports)
                .WithOne(t => t.Topic)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
