namespace MF.Services.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
                            .Where(c => c.IsDeleted == false)
                            .Select(c => new CategoryOutputViewModel()
                            {
                                Id = c.Id,
                                Title = c.Title,
                            })
                            .ToList();
        }

        public int CreateCategory(CategoryCreateViewModel input, string authorId)
        {
            var category = new Category()
            {
                Title = input.Title,
                AuthorId = authorId,
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();

            return category.Id;
        }

        public bool DeleteCategory(int categoryId)
        {
            var category = this.data.Categories.Find(categoryId);
            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;
            var isSaved = this.data.SaveChanges();

            return isSaved != 0 ? true : false;
        }

        public CategoryOutputViewModel GetById(int categoryId)
        {
            return this.data.Categories
                           .Where(c => c.IsDeleted == false)
                           .Select(c => new CategoryOutputViewModel()
                           {
                               Id = c.Id,
                               Title = c.Title,
                           })
                           .FirstOrDefault();
        }

        public CategoryDataOutputModel Details(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
