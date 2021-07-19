namespace MF.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(MFDbContext dbContext, IServiceProvider serviceProvider);
    }
}
