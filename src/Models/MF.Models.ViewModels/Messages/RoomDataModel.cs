namespace MF.Models.ViewModels.Messages
{
    using System;

    public class RoomDataModel
    {
        public int Id { get; set; }

        public string FirstParticipant { get; set; }

        public string SecondParticipant { get; set; }

        public string SenderId { get; set; }

        public string LastMessage { get; set; }

        public DateTime LastMessageOn { get; set; }
    }
}
