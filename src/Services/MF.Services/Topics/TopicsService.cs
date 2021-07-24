namespace MF.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels;
    using MF.Models.ViewModels.Topic;

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
            this.data.Topics.Find(topicId).IsDeleted = true;
            var isSave = this.data.SaveChanges();

            return isSave != 0 ? true : false;
        }
    }
}
