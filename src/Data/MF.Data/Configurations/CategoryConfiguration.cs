namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category
                    .Property(c => c.Title)
                    .HasMaxLength(30)
                    .IsRequired();

            category
                .HasOne(c => c.Author)
        }
    }
}
