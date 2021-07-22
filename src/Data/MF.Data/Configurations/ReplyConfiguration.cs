namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> reply)
        {
            reply
                .HasMany(r => r.ReplyReactions)
                .WithOne(r => r.Reply)
                .OnDelete(DeleteBehavior.Cascade);

            reply
                .HasMany(r => r.ReplyReports)
                .WithOne(r => r.Reply)
                .OnDelete(DeleteBehavior.Cascade);

            //Possible problems with DeleteBehavior !
            reply
               .HasOne(r => r.Author)
               .WithMany(r => r.Replies)
               .OnDelete(DeleteBehavior.SetNull);

            //Possible problems with DeleteBehavior !
            reply
               .HasOne(r => r.Topic)
               .WithMany(r => r.Replies)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
