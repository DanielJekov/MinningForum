namespace MF.Data.Configurations
{
    using MF.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            //category
            //        .HasMany(c => c.Topics)
            //        .WithOne(c => c.Category)
            //        .OnDelete(DeleteBehavior.Restrict);

            //category
            //       .HasOne(c => c.Author)
            //       .WithMany(c => c.Categories)
            //       .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
