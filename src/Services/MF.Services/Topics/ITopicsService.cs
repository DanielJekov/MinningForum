namespace MF.Services.Topics
{
    using System.Collections.Generic;

    using MF.Data.Models.Enums;
    using MF.Models.ViewModels.Topics;

    public interface ITopicsService
    {
        public int Create(TopicCreateInputModel input, string authorId);

        public bool Archivate(int topicId);

        public ICollection<TopicViewModel> GetArchives();

        public void Restore(int topicId);

        public void Delete(int topicId);

        public void Edit(int topicId);

        public void ChangeCategoryOnGivenTopic(ChangeCategoryOnTopicInputModel input);

        public ICollection<TopicViewModel> GetTopicsByCategory(int categoryId);

        public TopicRepliesViewModel GetDetails(int topicId, string userId);

        public bool IsOwner(string userId, int topicId);

        public bool IsExist(int topicId);

        public int GetIdByReplyId(int replyId);

        public void AddFollower(string followerId, int topicId);

        public void RemoveFollower(string followerId, int topicId);

        public bool IsFollower(string followerId, int topicId);

        public void AddReaction(string userId, int topicId, ReactionType reaction);

        public void RemoveReaction(string userId, int topicId);

        public bool IsReacted(string userId, int topicId);

        public bool IsSameReaction(string userId, int topicId, ReactionType reaction);

        public void ChangeReaction(string userId, int topicId, ReactionType reaction);
    }
}
