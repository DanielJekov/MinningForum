namespace MF.Models.ViewModels.Replies
{
    using System;

    using Ganss.XSS;

    public class QuoteReplyViewModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }
    }
}
