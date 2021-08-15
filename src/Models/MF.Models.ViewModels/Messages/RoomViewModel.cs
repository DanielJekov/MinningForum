namespace MF.Models.ViewModels.Messages
{
    using System;

    using Ganss.XSS;

    public class RoomViewModel
    {
        public string RoomId { get; set; }

        public string RoomName { get; set; }

        public string SenderUsername { get; set; }

        public string LastMessage { get; set; }

        public string LastMessageSanitized => new HtmlSanitizer().Sanitize(this.LastMessage);

        public DateTime LastMessageOn { get; set; }
    }
}
