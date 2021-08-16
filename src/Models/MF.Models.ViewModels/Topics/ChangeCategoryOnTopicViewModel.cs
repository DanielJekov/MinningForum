namespace MF.Models.ViewModels.Topics
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Categories;

    public class ChangeCategoryOnTopicViewModel
    {
        public int TopicId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
