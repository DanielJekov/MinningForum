namespace MF.Models.ViewModels.Reply
{
    using Ganss.XSS;

    public class ReplyOutputViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public bool IsUserOwnReply { get; set; }

        public string Author { get; set; }

        public string CreatedOn { get; set; }
    }
}
