namespace MF.Services.Replies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Data.Models.Enums;
    using MF.Models.ViewModels.Reactions;
    using MF.Models.ViewModels.Replies;

    public class RepliesService : IRepliesService
    {
        private readonly MFDbContext data;

        public RepliesService(MFDbContext data)
        {
            this.data = data;
        }

        public void Create(ReplyCreateInputModel input, string authorId)
        {
            var quoteReply = this.data.Replies.FirstOrDefault(r => r.Id == input.QuoteReplyId);

            if (quoteReply == null)
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
            else
            {
                var reply = new Reply()
                {
                    Content = input.Content,
                    AuthorId = authorId,
                    TopicId = input.TopicId.Value,
                    QuoteReplyId = input.QuoteReplyId,
                };

                this.data.Replies.Add(reply);
                this.data.SaveChanges();
            }
        }

        public bool Archivate(int replyId)
        {
            var reply = this.data.Replies
                                 .Where(r => r.IsDeleted == false &&
                                             r.Id == replyId)
                                 .FirstOrDefault();

            if (reply == null)
            {
                return false;
            }

            reply.IsDeleted = true;
            reply.DeletedOn = DateTime.UtcNow;
            this.data.SaveChanges();

            return true;
        }

        public ICollection<ReplyViewModel> GetArchives()
        {
            return this.data.Replies
                            .Where(r => r.IsDeleted == true)
                            .Select(r => new ReplyViewModel()
                            {
                                Id = r.Id,
                                Content = r.Content,
                                Author = r.Author.UserName,
                                CreatedOn = r.CreatedOn,
                                QuoteReply = r.QuoteReply != null ? new QuoteReplyViewModel
                                {
                                    Author = r.QuoteReply.Author.UserName,
                                    Content = r.QuoteReply.Content,
                                    CreatedOn = r.QuoteReply.CreatedOn,
                                }
                                : null,
                                ReactionsCount = new ReactionsCountViewModel
                                {
                                    Like = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Like).Count(),
                                    Love = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Love).Count(),
                                    Funny = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Funny).Count(),
                                    Angry = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Angry).Count(),
                                    Sad = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Sad).Count(),
                                },
                            })
                            .ToList();
        }

        public void Restore(int replyId)
        {
            var reply = this.data.Replies.Find(replyId);
            reply.IsDeleted = false;
            reply.DeletedOn = null;

            this.data.SaveChanges();
        }

        public void Delete(int replyId)
        {
            throw new NotImplementedException();
        }

        public void Edit(int replyId)
        {
            throw new NotImplementedException();
        }

        public ICollection<ReplyViewModel> GetRepliesByTopic(int topicId, string userId)
        {
            return this.data.Replies
                            .Where(r => r.Topic.Id == topicId)
                            .Where(r => r.IsDeleted == false)
                            .Select(r => new ReplyViewModel()
                            {
                                Id = r.Id,
                                Content = r.Content,
                                Author = r.Author.UserName,
                                CreatedOn = r.CreatedOn,
                                IsUserOwner = r.Author.Id == userId,
                                QuoteReply = r.QuoteReply != null ? new QuoteReplyViewModel
                                {
                                    Author = r.QuoteReply.Author.UserName,
                                    Content = r.QuoteReply.Content,
                                    CreatedOn = r.QuoteReply.CreatedOn,
                                }
                                : null,
                                ReactionsCount = new ReactionsCountViewModel
                                {
                                    Like = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Like).Count(),
                                    Love = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Love).Count(),
                                    Funny = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Funny).Count(),
                                    Angry = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Angry).Count(),
                                    Sad = r.ReplyReactions.Where(x => x.ReactionType == ReactionType.Sad).Count(),
                                },
                            })
                            .ToList();
        }

        public bool IsExist(int replyId)
        {
            return this.data.Replies
                            .Where(r => r.IsDeleted == false)
                            .Any(r => r.Id == replyId);
        }

        public bool IsOwner(string userId, int replyId)
        {
            return this.data.Replies
                            .Where(r => r.Id == replyId)
                            .Any(x => x.Author.Id == userId);
        }

        public void AddReaction(string userId, int replyId, ReactionType reaction)
        {
            var replyReacion = new ReplyReaction()
            {
                ReactionType = reaction,
                ReplyId = replyId,
                AuthorId = userId,
            };

            this.data.ReplyReactions.Add(replyReacion);
            this.data.SaveChanges();
        }

        public void RemoveReaction(string userId, int replyId)
        {
            var reaction = this.data.ReplyReactions
                                    .FirstOrDefault(x => x.Author.Id == userId &&
                                                         x.Reply.Id == replyId);
            this.data.ReplyReactions.Remove(reaction);
            this.data.SaveChanges();
        }

        public void ChangeReaction(string userId, int replyId, ReactionType reaction)
        {
            var replyReaction = this.data.ReplyReactions
                                    .FirstOrDefault(x => x.Author.Id == userId &&
                                                         x.Reply.Id == replyId);
            replyReaction.ReactionType = reaction;
            this.data.SaveChanges();
        }

        public bool IsReacted(string userId, int replyId)
        {
            var reaction = this.data.ReplyReactions
                                    .FirstOrDefault(x => x.Author.Id == userId &&
                                                         x.Reply.Id == replyId);

            return reaction != null;
        }

        public bool IsSameReaction(string userId, int replyId, ReactionType reaction)
        {
            var replyReaction = this.data.ReplyReactions
                                         .Where(x => x.Author.Id == userId &&
                                                     x.Reply.Id == replyId)
                                         .Select(x => x.ReactionType)
                                         .FirstOrDefault();

            return (int)replyReaction == (int)reaction;
        }
    }
}
