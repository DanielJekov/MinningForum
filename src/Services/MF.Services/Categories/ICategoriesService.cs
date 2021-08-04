namespace MF.Services.Categories
{
    using System.Collections.Generic;

    using MF.Models.ViewModels;

    using MF.Models.ViewModels.Category;

    public interface ICategoriesService
    {
        public ICollection<CategoryOutputViewModel> All();

        public CategoryOutputViewModel GetById(int categoryId);

        public CategoryDetailsViewModel GetDetails(int categoryId);

        public int Create(CategoryCreateViewModel input, string authorId);

        public bool Delete(int categoryId);
    }
}
