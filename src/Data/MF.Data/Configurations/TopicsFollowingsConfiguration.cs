namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TopicsFollowingsConfiguration : IEntityTypeConfiguration<TopicFollower>
    {
        public void Configure(EntityTypeBuilder<TopicFollower> entity)
        {
            entity
                 .HasOne(e => e.Topic)
                 .WithMany(e => e.Followers)
                 .HasForeignKey(e => e.TopicId);

            entity
                .HasOne(e => e.Follower)
                .WithMany(e => e.FollowedTopics)
                .HasForeignKey(e => e.FollowerId);
        }
    }
}
