namespace MF.Services.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels.Categories;

    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly MFDbContext data;

        public CategoriesService(MFDbContext data)
        {
            this.data = data;
        }

        public int Create(CategoryCreateInputModel input, string authorId)
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

        public bool Archivate(int categoryId)
        {
            var category = this.data.Categories.Find(categoryId);
            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;
            var isSaved = this.data.SaveChanges();

            return isSaved != 0;
        }

        public ICollection<CategoryViewModel> GetArchives()
        {
            return this.GetAll(true);
        }

        public void Restore(int categoryId)
        {
            var category = this.data.Categories.Find(categoryId);
            category.IsDeleted = false;
            category.DeletedOn = null;

            this.data.SaveChanges();
        }

        public string GetName(int categoryId)
        {
            return this.data.Categories
                            .Where(c => c.Id == categoryId)
                            .Select(c => c.Name)
                            .FirstOrDefault();
        }

        public void Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Edit(CategoryEditInputModel input)
        {
            var category = this.data.Categories.Find(input.Id);

            category.Name = input.NewName;
            this.data.SaveChanges();
        }

        public ICollection<CategoryViewModel> GetAll(bool isDeleted = false)
        {
            return this.data.Categories
                            .Where(c => c.IsDeleted == isDeleted)
                            .Select(c => new CategoryViewModel()
                            {
                                Id = c.Id,
                                Name = c.Name,
                            })
                            .ToList();
        }

        public CategoryTopicsViewModel GetDetails(string userId, int categoryId)
        {
            return this.data.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new CategoryTopicsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsFollowed = c.Followers
                                  .Any(f => f.Follower.Id == userId),
                    ParticipantsCount = c.Topics.Select(x => x.Replies.Select(x => x.Author.Id).Distinct().Count()).FirstOrDefault(),
                })
                .FirstOrDefault();
        }

        public bool IsExist(int categoryId)
        {
            return this.data.Categories
                            .Where(category => category.IsDeleted == false)
                            .Any(category => category.Id == categoryId);
        }

        public int GetIdByTopicId(int topicId)
        {
            return this.data.Topics
                            .Where(t => t.Id == topicId)
                            .Select(c => c.Category.Id)
                            .FirstOrDefault();
        }

        public void AddFollower(int categoryId, string userId)
        {
            this.data.CategoryFollowers.Add(new CategoryFollower { CategoryId = categoryId, FollowerId = userId });
            this.data.SaveChanges();
        }

        public void RemoveFollower(int categoryId, string userId)
        {
            var follower = this.data.CategoryFollowers
                                    .Where(c => c.FollowerId == userId &&
                                                c.CategoryId == categoryId)
                                    .FirstOrDefault();

            this.data.CategoryFollowers.Remove(follower);
            this.data.SaveChanges();
        }

        public bool IsFollower(string followerId, int categoryId)
        {
            return this.data.Categories
                            .Where(category => category.Id == categoryId)
                            .Any(x => x.Followers.FirstOrDefault(s => s.Follower.Id == followerId) != null);
        }
    }
}
