namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MFUserConfiguration : IEntityTypeConfiguration<MFUser>
    {
        public void Configure(EntityTypeBuilder<MFUser> builder)
        {
        }
    }
}
