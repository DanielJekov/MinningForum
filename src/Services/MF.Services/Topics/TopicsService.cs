namespace MF.Services.Topics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Data.Models.Enums;
    using MF.Models.ViewModels.Reactions;
    using MF.Models.ViewModels.Replies;
    using MF.Models.ViewModels.Topics;

    using Microsoft.EntityFrameworkCore;

    public class TopicsService : ITopicsService
    {
        private readonly MFDbContext data;

        public TopicsService(MFDbContext data)
        {
            this.data = data;
        }

        public int Create(TopicCreateInputModel input, string authorId)
        {
            var topic = new Topic()
            {
                Name = input.Name,
                CategoryId = input.CategoryId.Value,
                AuthorId = authorId,
            };

            this.data.Topics.Add(topic);
            this.data.SaveChanges();

            return topic.Id;
        }

        public bool Delete(int topicId)
        {
            var topic = this.data.Topics.Find(topicId);
            topic.IsDeleted = true;
            topic.DeletedOn = DateTime.UtcNow;

            var isSave = this.data.SaveChanges();

            return isSave != 0;
        }

        public void Edit(int topicId)
        {
            throw new NotImplementedException();
        }

        public ICollection<TopicViewModel> GetTopicsByCategory(int categoryId)
        {
            return this.data.Topics
                    .Where(t => t.Category.Id == categoryId)
                    .Where(t => t.IsDeleted == false)
                    .Select(topic => new TopicViewModel()
                    {
                        Id = topic.Id,
                        Name = topic.Name,
                        AuthorId = topic.Author.Id,
                        AuthorUsername = topic.Author.UserName,
                        LastReplyInfo = topic.Replies
                                         .OrderByDescending(r => r.CreatedOn)
                                         .Select(r => new LastReplyInfoViewModel()
                                         {
                                             AuthorId = r.Author.Id,
                                             AuthorUsername = r.Author.UserName,
                                             CreatedOn = r.CreatedOn,
                                         })
                                         .FirstOrDefault(),
                        PublishedOn = topic.CreatedOn,
                        RepliesCount = topic.Replies.Count,
                        ReactionsCount = topic.TopicReactions.Count,
                    })
                    .ToList();
        }

        public TopicRepliesViewModel GetDetails(int topicId, string userId)
        {
            return this.data.Topics
                            .Where(t => t.Id == topicId)
                            .Include(t => t.Replies.Where(x => x.IsDeleted == false))
                            .Select(t => new TopicRepliesViewModel()
                            {
                                Id = t.Id,
                                Name = t.Name,
                                CreatedOn = t.Replies.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedOn).Select(x => x.CreatedOn).FirstOrDefault(),
                                LastReplyOn = t.Replies.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).FirstOrDefault(),
                                IsFollowed = t.Followers.Any(f => f.Follower.Id == userId),
                                ReactionsCount = new ReactionsCountViewModel
                                {
                                    Like = t.TopicReactions.Where(r => r.ReactionType == ReactionType.Like).Count(),
                                    Love = t.TopicReactions.Where(r => r.ReactionType == ReactionType.Love).Count(),
                                    Funny = t.TopicReactions.Where(r => r.ReactionType == ReactionType.Funny).Count(),
                                    Angry = t.TopicReactions.Where(r => r.ReactionType == ReactionType.Angry).Count(),
                                    Sad = t.TopicReactions.Where(r => r.ReactionType == ReactionType.Sad).Count(),
                                },
                            })
                            .FirstOrDefault();
        }

        public bool IsOwner(string userId, int topicId)
        {
            return this.data.Topics
                            .Where(r => r.Id == topicId)
                            .Any(x => x.Author.Id == userId);
        }

        public bool IsExist(int topicId)
        {
            return this.data.Topics
                            .Where(t => t.IsDeleted == false)
                            .Any(t => t.Id == topicId);
        }

        public int GetIdByReplyId(int replyId)
        {
            return this.data.Replies
                            .Where(r => r.Id == replyId)
                            .Select(r => r.Topic.Id)
                            .FirstOrDefault();
        }

        public void AddFollower(string followerId, int topicId)
        {
            var topicsFollowing = this.data.TopicFollowers
                                           .FirstOrDefault(x => x.FollowerId == followerId && x.TopicId == topicId);

            this.data.TopicFollowers.Add(new TopicFollower { TopicId = topicId, FollowerId = followerId });
            this.data.SaveChanges();
        }

        public void RemoveFollower(string followerId, int topicId)
        {
            var topicsFollowing = this.data.TopicFollowers
                                           .FirstOrDefault(x => x.FollowerId == followerId && x.TopicId == topicId);

            this.data.TopicFollowers.Remove(topicsFollowing);
            this.data.SaveChanges();
        }

        public bool IsFollower(string followerId, int topicId)
        {
            return this.data.Topics
                            .Where(topic => topic.Id == topicId)
                            .Any(x => x.Followers.FirstOrDefault(s => s.Follower.Id == followerId) != null);
        }

        public void AddReaction(string userId, int topicId, ReactionType reaction)
        {
            var topicReaction = new TopicReaction()
            {
                ReactionType = reaction,
                TopicId = topicId,
                AuthorId = userId,
            };

            this.data.TopicReactions.Add(topicReaction);
            this.data.SaveChanges();
        }

        public void RemoveReaction(string userId, int topicId)
        {
            var reaction = this.data.TopicReactions
                                     .FirstOrDefault(x => x.Author.Id == userId &&
                                                          x.Topic.Id == topicId);
            this.data.TopicReactions.Remove(reaction);
            this.data.SaveChanges();
        }

        public void ChangeReaction(string userId, int topicId, ReactionType reaction)
        {
            var topicReaction = this.data.TopicReactions
                                    .FirstOrDefault(x => x.Author.Id == userId &&
                                                         x.Topic.Id == topicId);
            topicReaction.ReactionType = reaction;
            this.data.SaveChanges();
        }

        public bool IsReacted(string userId, int topicId)
        {
            var reaction = this.data.TopicReactions
                                    .FirstOrDefault(x => x.Author.Id == userId &&
                                                         x.Topic.Id == topicId);

            return reaction != null;
        }

        public bool IsSameReaction(string userId, int topicId, ReactionType reaction)
        {
            var topicReaction = this.data.TopicReactions
                                         .Where(x => x.Author.Id == userId &&
                                                     x.Topic.Id == topicId)
                                         .Select(x => x.ReactionType)
                                         .FirstOrDefault();

            return (int)topicReaction == (int)reaction;
        }
    }
}
