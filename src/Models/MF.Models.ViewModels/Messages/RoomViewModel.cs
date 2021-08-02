namespace MF.Models.ViewModels.Messages
{
    using System;

    public class RoomViewModel
    {
        public int Id { get; set; }

        public string RoomName { get; set; }

        public string SenderUsername { get; set; }

        public string LastMessage { get; set; }

        public DateTime LastMessageOn { get; set; }
    }
}
