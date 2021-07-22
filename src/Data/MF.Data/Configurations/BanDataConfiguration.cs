namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BanDataConfiguration : IEntityTypeConfiguration<BanData>
    {
        public void Configure(EntityTypeBuilder<BanData> banData)
        {
        }
    }
}
