namespace MF.Models.ViewModels.Topics
{
    using System;

    using MF.Models.ViewModels.Replies;

    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }

        public DateTime PublishedOn { get; set; }

        public LastReplyInfoViewModel LastReplyInfo { get; set; }

        public int ViewsCount { get; set; }

        public int RepliesCount { get; set; }

        public int ReactionsCount { get; set; }
    }
}
