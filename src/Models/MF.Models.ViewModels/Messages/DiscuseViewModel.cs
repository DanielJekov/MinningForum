namespace MF.Models.ViewModels.Messages
{
    using System;

    public class DiscuseViewModel
    {
        public string ReceiverUsername { get; set; }

        public string SenderUsername { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
