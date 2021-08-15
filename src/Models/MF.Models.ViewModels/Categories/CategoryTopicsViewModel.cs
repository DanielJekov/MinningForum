namespace MF.Models.ViewModels.Categories
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Topics;

    public class CategoryTopicsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsFollowed { get; set; }

        public int TopicsCount => this.Topics.Count;

        public int ParticipantsCount { get; set; }

        public ICollection<TopicViewModel> Topics { get; set; }
    }
}
