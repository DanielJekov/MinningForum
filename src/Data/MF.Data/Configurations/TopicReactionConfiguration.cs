namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TopicReactionConfiguration : IEntityTypeConfiguration<TopicReaction>
    {
        public void Configure(EntityTypeBuilder<TopicReaction> topicReaction)
        {
        }
    }
}
