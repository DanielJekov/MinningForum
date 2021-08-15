namespace MF.Services.Replies
{
    using System.Collections.Generic;

    using MF.Data.Models.Enums;
    using MF.Models.ViewModels.Replies;

    public interface IRepliesService
    {
        public void Create(ReplyCreateInputModel input, string authorId);

        public bool Delete(int replyId);

        public void Edit(int replyId);

        public ICollection<ReplyViewModel> GetRepliesByTopic(int topicId, string userId);

        public bool IsExist(int replyId);

        public bool IsOwner(string userId, int replyId);

        public void AddReaction(string userId, int replyId, ReactionType reaction);

        public void RemoveReaction(string userId, int replyId);

        public void ChangeReaction(string userId, int replyId, ReactionType reaction);

        public bool IsReacted(string userId, int replyId);

        public bool IsSameReaction(string userId, int replyId, ReactionType reaction);
    }
}
