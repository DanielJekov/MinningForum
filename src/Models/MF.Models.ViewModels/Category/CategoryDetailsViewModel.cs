namespace MF.Models.ViewModels.Category
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Topic;

    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TopicsCount => this.Topics.Count;

        public int ParticipantsCount { get; set; }

        public ICollection<TopicViewModel> Topics { get; set; }
    }
}
