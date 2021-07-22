namespace MF.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels;
    using MF.Models.ViewModels.Reply;

    public class RepliesService : IRepliesService
    {
        private readonly MFDbContext data;

        public RepliesService(MFDbContext data)
        {
            this.data = data;
        }

        public ICollection<ReplyOutputViewModel> All(int topicId)
        {
            return this.data.Replies
                .Where(r => r.Topic.Id == topicId)
                .Select(r => new ReplyOutputViewModel()
                {
                    Id = r.Id,
                    Content = r.Content,
                    Author = r.Author.Email,
                    CreatedOn = r.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                })
                .ToList();
        }

        public void CreateReply(ReplyCreateViewModel input, string authorId)
        {
            var reply = new Reply()
            {
                Content = input.Content,
                AuthorId = authorId,
                TopicId = input.TopicId.Value,
            };

            this.data.Replies.Add(reply);
            this.data.SaveChanges();
        }

        public bool DeleteReply(int replyId)
        {
            this.data.Replies.Find(replyId).IsDeleted = true;
            var isSaved = this.data.SaveChanges();

            return isSaved != 0 ? true : false;
        }
    }
}
