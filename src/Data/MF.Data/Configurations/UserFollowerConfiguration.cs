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
                .WithMany(ff => ff.Followers)
                .OnDelete(DeleteBehavior.Restrict);

            // userFollower
            //             .HasOne(uf => uf.User)
            //             .WithMany(u => u.Followers)
            //             .HasForeignKey(uf => uf.UserId)
            //             .IsRequired()
            //             .OnDelete(DeleteBehavior.Restrict);

            // userFollower
            //             .HasOne(uf => uf.Follower)
            //             .WithMany()
            //             .HasForeignKey(uf => uf.FollowerId)
            //             .IsRequired()
            //             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
