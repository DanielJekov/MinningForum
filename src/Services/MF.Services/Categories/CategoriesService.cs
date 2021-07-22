namespace MF.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels;
    using MF.Models.ViewModels.Category;

    public class CategoriesService : ICategoriesService
    {
        private readonly MFDbContext data;

        public CategoriesService(MFDbContext data)
        {
            this.data = data;
        }

        public ICollection<CategoryOutputViewModel> All()
        {
            return this.data.Categories
                            .Select(c => new CategoryOutputViewModel()
                            {
                                Id = c.Id,
                                Title = c.Title,
                            })
                            .ToList();
        }

        public void CreateCategory(CategoryCreateViewModel input, string authorId)
        {
            var category = new Category()
            {
                Title = input.Title,
                AuthorId = authorId,
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();
        }

        public bool DeleteCategory(int categoryId)
        {
            this.data.Categories.Find(categoryId).IsDeleted = true;
            var isSaved = this.data.SaveChanges();

            return isSaved != 0 ? true : false;
        }
    }
}
