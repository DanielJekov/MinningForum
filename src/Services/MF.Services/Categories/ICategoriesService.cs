namespace MF.Services.Categories
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Categories;

    public interface ICategoriesService
    {
        public int Create(CategoryCreateInputModel input, string authorId);

        public bool Archivate(int categoryId);

        public ICollection<CategoryViewModel> GetArchives();

        public string GetName(int categoryId);

        public void Restore(int categoryId);

        public void Delete(int categoryId);

        public void Edit(CategoryEditInputModel input);

        public ICollection<CategoryViewModel> GetAll(bool isDeleted);

        public CategoryTopicsViewModel GetDetails(string userId, int categoryId);

        public bool IsExist(int categoryId);

        public int GetIdByTopicId(int topicId);

        public void AddFollower(int categoryId, string userId);

        public void RemoveFollower(int categoryId, string userI);

        public bool IsFollower(string followerId, int categoryId);
    }
}
