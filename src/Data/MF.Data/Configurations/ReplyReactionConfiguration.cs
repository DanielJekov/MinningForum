namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReplyReactionConfiguration : IEntityTypeConfiguration<ReplyReaction>
    {
        public void Configure(EntityTypeBuilder<ReplyReaction> replyReaction)
        {
        }
    }
}
