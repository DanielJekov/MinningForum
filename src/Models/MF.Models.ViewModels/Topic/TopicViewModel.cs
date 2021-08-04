namespace MF.Models.ViewModels.Topic
{
    using System;

    using MF.Models.ViewModels.Reply;

    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorUsername { get; set; }

        public DateTime PublishedOn { get; set; }

        public LastReplyInfo LastReplyInfo { get; set; }

        public int ViewsCount { get; set; }

        public int RepliesCount { get; set; }

        public int ReactionsCount { get; set; }
    }
}
