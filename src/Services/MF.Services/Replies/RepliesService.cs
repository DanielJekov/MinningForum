namespace MF.Services.Replies
{
    using System;
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

        public ICollection<ReplyOutputViewModel> RepliesByTopicId(int topicId, string userId)
        {

            return this.data.Replies
                .Where(r => r.Topic.Id == topicId)
                .Where(r => r.IsDeleted == false)
                .Select(r => new ReplyOutputViewModel()
                {
                    Id = r.Id,
                    Content = r.Content,
                    Author = r.Author.UserName,
                    CreatedOn = r.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                    IsUserOwnReply = r.Author.Id == userId,
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
            var reply = this.data.Replies.Find(replyId);
            reply.IsDeleted = true;
            reply.DeletedOn = DateTime.UtcNow;

            var isSaved = this.data.SaveChanges();

            return isSaved != 0 ? true : false;
        }
    }
}
