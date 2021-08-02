namespace MF.Services.Topics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels.Topic;

    using Microsoft.EntityFrameworkCore;

    public class TopicsService : ITopicsService
    {
        private readonly MFDbContext data;

        public TopicsService(MFDbContext data)
        {
            this.data = data;
        }

        public ICollection<TopicViewModel> All(int categoryId)
        {
            return this.data.Topics
                    .Where(t => t.Category.Id == categoryId)
                    .Where(t => t.IsDeleted == false)
                    .Select(t => new TopicViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                    })
                    .ToList();
        }

        public int Create(TopicCreateInputModel input, string authorId)
        {
            var topic = new Topic()
            {
                Title = input.Name,
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

            return isSave != 0 ? true : false;
        }

        public TopicDetailsViewModel Details(int topicId)
        {
            var dateFormat = "dd.MM.yyyy HH:mm";

            return this.data.Topics
                 .Where(t => t.Id == topicId)
                 .Include(t => t.Replies.Where(x => x.IsDeleted == false))
                 .Select(t => new TopicDetailsViewModel()
                 {
                     Title = t.Title,
                     FirstPublish = t.Replies.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedOn).Select(x => x.CreatedOn).First().ToString(dateFormat),
                     LastPublish = t.Replies.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).First().ToString(dateFormat),

                 })
                 .FirstOrDefault();
        }

        public void AddFollower(string followerId, int topicId)
        {
            var topicsFollowing = this.data.TopicsFollowings
                  .FirstOrDefault(x => x.FollowerId == followerId && x.TopicId == topicId);

            if (topicsFollowing == null)
            {
                this.data.TopicsFollowings.Add(new TopicsFollowings { TopicId = topicId, FollowerId = followerId });
                this.data.SaveChanges();
            }
        }

        public void RemoveFollower(string followerId, int topicId)
        {
            var topicsFollowing = this.data.TopicsFollowings
                .FirstOrDefault(x => x.FollowerId == followerId && x.TopicId == topicId);

            if (topicsFollowing != null)
            {
                this.data.TopicsFollowings.Remove(topicsFollowing);
                this.data.SaveChanges();
            }
        }

        public bool IsFollower(string followerId, int topicId)
        {
            return this.data.Topics
                        .Include(x => x.Followers)
                        .FirstOrDefault(x => x.Id == topicId)
                        .Followers
                        .Any(x => x.FollowerId == followerId);
        }

        public bool IsOwner(string userId, int topicId)
        {
            return this.data.Topics
                             .Where(r => r.Id == topicId)
                             .Any(x => x.Author.Id == userId);
        }
    }
}
