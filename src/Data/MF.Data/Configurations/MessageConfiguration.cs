namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> message)
        {
            message
                .HasOne(x => x.Receiver)
                .WithMany(x => x.MessageInbox)
                .OnDelete(DeleteBehavior.NoAction);

            message
              .HasOne(x => x.Sender)
              .WithMany(x => x.MessageOutbox)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
