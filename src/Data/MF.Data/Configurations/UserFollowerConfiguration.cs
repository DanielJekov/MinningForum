namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> follower)
        {
            follower
                .HasOne(ff => ff.FollowerUser)
                .WithMany(ff => ff.FollowerUsers)
                .HasForeignKey(ff => ff.FollowerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            follower
                .HasOne(ff => ff.FollowedUser)
                .WithMany(ff => ff.FollowedUsers)
                .HasForeignKey(ff => ff.FollowedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
