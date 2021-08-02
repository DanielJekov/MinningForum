namespace MF.Models.ViewModels.Messages
{
    using System;

    using Ganss.XSS;

    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string CurrUser { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
