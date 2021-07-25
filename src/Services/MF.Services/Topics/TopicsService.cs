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

        public ICollection<TopicOutputViewModel> All(int categoryId)
        {
            return this.data.Topics
                    .Where(t => t.Category.Id == categoryId)
                    .Where(t => t.IsDeleted == false)
                    .Select(t => new TopicOutputViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                    })
                    .ToList();
        }

        public int CreateTopic(TopicCreateViewModel input, string authorId)
        {
            var topic = new Topic()
            {
                Title = input.Title,
                CategoryId = input.CategoryId.Value,
                AuthorId = authorId,
            };

            this.data.Topics.Add(topic);
            this.data.SaveChanges();

            return topic.Id;
        }

        public bool DeleteTopic(int topicId)
        {
            var topic = this.data.Topics.Find(topicId);
            topic.IsDeleted = true;
            topic.DeletedOn = DateTime.UtcNow;

            var isSave = this.data.SaveChanges();

            return isSave != 0 ? true : false;
        }

        public TopicDetailsOutputModel Details(int topicId)
        {
            var dateFormat = "dd.MM.yyyy HH:mm";

            return this.data.Topics
                 .Where(t => t.Id == topicId)
                 .Include(t => t.Replies.Where(x => x.IsDeleted == false))
                 .Select(t => new TopicDetailsOutputModel()
                 {
                     Title = t.Title,
                     FirstPublish = t.Replies.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedOn).Select(x => x.CreatedOn).First().ToString(dateFormat),
                     LastPublish = t.Replies.Where(x => x.IsDeleted == false).OrderByDescending(x => x.CreatedOn).Select(x => x.CreatedOn).First().ToString(dateFormat),

                 })
                 .FirstOrDefault();
        }
    }
}
