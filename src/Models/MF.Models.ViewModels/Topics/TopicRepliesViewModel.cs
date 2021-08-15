namespace MF.Models.ViewModels.Topics
{
    using System;
    using System.Collections.Generic;

    using MF.Models.ViewModels.Reactions;
    using MF.Models.ViewModels.Replies;

    public class TopicRepliesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsFollowed { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastReplyOn { get; set; }

        public ReactionsCountViewModel ReactionsCount { get; set; }

        public ICollection<ReplyViewModel> Replies { get; set; }
    }
}
