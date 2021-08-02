namespace MF.Services.Messages
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Messages;

    public interface IMessagesService
    {
        public bool New(string senderId, string receiverId, string content);

        public ICollection<MessageViewModel> AllBetweenUsers(string senderId, string receiverId);

        public ICollection<DiscuseViewModel> Rooms(string userId);

        public IEnumerable<RoomViewModel> GetChatMembers(string userId);
    }
}