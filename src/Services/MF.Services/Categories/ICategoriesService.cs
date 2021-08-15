﻿namespace MF.Services.Categories
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Categories;

    public interface ICategoriesService
    {
        public int Create(CategoryCreateInputModel input, string authorId);

        public bool Delete(int categoryId);

        public void Edit(CategoryEditInputModel input);

        public ICollection<CategoryViewModel> GetAll();

        public CategoryTopicsViewModel GetDetails(string userId, int categoryId);

        public bool IsExist(int categoryId);

        public int GetIdByTopicId(int topicId);

        public void AddFollower(int categoryId, string userId);

        public void RemoveFollower(int categoryId, string userI);

        public bool IsFollower(string followerId, int categoryId);
    }
}
