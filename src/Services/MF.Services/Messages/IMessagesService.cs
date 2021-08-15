namespace MF.Services.Messages
{
    using System.Collections.Generic;

    using MF.Models.ViewModels.Messages;

    public interface IMessagesService
    {
        public bool New(string senderId, string receiverId, string content);

        public ICollection<MessageViewModel> MessagesBetweenUsers(string senderId, string receiverId);

        public IEnumerable<RoomViewModel> GetRooms(string userId);

        public IEnumerable<UserViewModel> GetAllUsers();
    }
}
