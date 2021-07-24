namespace MF.Services
{
    using System.Collections.Generic;

    using MF.Models.ViewModels;
    using MF.Models.ViewModels.Topic;

    public interface ITopicsService
    {
        public ICollection<TopicOutputViewModel> All(int categoryId);

        public int CreateTopic(TopicCreateViewModel input, string authorId);

        public bool DeleteTopic(int topicId);
        public TopicDetailsOutputModel Details(int topicId);
    }
}
