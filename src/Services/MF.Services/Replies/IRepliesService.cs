namespace MF.Services
{
    using System.Collections.Generic;

    using MF.Models.ViewModels;
    using MF.Models.ViewModels.Reply;

    public interface IRepliesService
    {
        public ICollection<ReplyOutputViewModel> All(int topicId);

        public void CreateReply(ReplyCreateViewModel input, string authorId);

        public bool DeleteReply(int replyId);
    }
}
