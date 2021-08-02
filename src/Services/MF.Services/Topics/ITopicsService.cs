namespace MF.Services.Topics
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Topic;

    public interface ITopicsService
    {
        public ICollection<TopicViewModel> All(int categoryId);

        public int Create(TopicCreateInputModel input, string authorId);

        public bool Delete(int topicId);

        public TopicDetailsViewModel Details(int topicId);

        public void AddFollower(string followerId, int topicId);

        public void RemoveFollower(string followerId, int topicId);

        public bool IsFollower(string followerId, int topicId);

        public bool IsOwner(string userId, int topicId);
    }
}
