namespace MF.Services.Replies
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Reply;

    public interface IRepliesService
    {
        public ICollection<ReplyOutputViewModel> RepliesByTopic(int topicId, string userId);

        public void Create(ReplyCreateViewModel input, string authorId);

        public bool Delete(int replyId);

        public bool IsOwner(string userId, int replyId);
    }
}
