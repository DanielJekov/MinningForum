namespace MF.Services.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
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
                                Title = c.Name,
                            })
                            .ToList();
        }

        public CategoryOutputViewModel GetById(int categoryId)
        {
            return this.data.Categories
                           .Where(c => c.IsDeleted == false)
                           .Select(c => new CategoryOutputViewModel()
                           {
                               Id = c.Id,
                               Title = c.Name,
                           })
                           .FirstOrDefault();
        }

        public int Create(CategoryCreateViewModel input, string authorId)
        {
            var category = new Category()
            {
                Name = input.Name,
                AuthorId = authorId,
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();

            return category.Id;
        }

        public bool Delete(int categoryId)
        {
            var category = this.data.Categories.Find(categoryId);
            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;
            var isSaved = this.data.SaveChanges();

            return isSaved != 0 ? true : false;
        }

        public CategoryDetailsViewModel GetDetails(int categoryId)
        {
            return this.data.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new CategoryDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParticipantsCount = 0,
                })
                .FirstOrDefault();
        }
    }
}
