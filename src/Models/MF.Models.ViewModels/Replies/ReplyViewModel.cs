namespace MF.Models.ViewModels.Replies
{
    using System;

    using Ganss.XSS;

    using MF.Models.ViewModels.Reactions;

    public class ReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public QuoteReplyViewModel QuoteReply { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public bool IsUserOwner { get; set; }

        public ReactionsCountViewModel ReactionsCount { get; set; }
    }
}
