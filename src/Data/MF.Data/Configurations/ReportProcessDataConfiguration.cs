namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReportProcessDataConfiguration : IEntityTypeConfiguration<ReportProcessData>
    {
        public void Configure(EntityTypeBuilder<ReportProcessData> reportProcessData)
        {
        }
    }
}
