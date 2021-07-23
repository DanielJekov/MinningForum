namespace MF.Services
{
    using System.Collections.Generic;

    using MF.Models.ViewModels;

    using MF.Models.ViewModels.Category;

    public interface ICategoriesService
    {
        public int CreateCategory(CategoryCreateViewModel input, string authorId);

        public bool DeleteCategory(int categoryId);

        public ICollection<CategoryOutputViewModel> All();

        public CategoryOutputViewModel GetById(int categoryId);
    }
}
