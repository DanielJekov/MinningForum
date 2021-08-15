namespace MF.Services.Messages
{
    using System.Collections.Generic;
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels.Messages;

    public class MessagesService : IMessagesService
    {
        private readonly MFDbContext data;

        public MessagesService(MFDbContext data)
        {
            this.data = data;
        }

        public bool New(string senderId, string receiverId, string content)
        {
            var message = new Message()
            {
                Content = content,
                SenderId = senderId,
                ReceiverId = receiverId,
            };

            this.data.Messages.Add(message);
            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return this.data.Users
                  .Select(u => new UserViewModel
                  {
                      ReceiverId = u.Id,
                      Username = u.UserName,
                  })
                  .ToHashSet();
        }

        public ICollection<MessageViewModel> MessagesBetweenUsers(string senderId, string receiverId)
        {
            return this.data.Messages
                            .Where(m => (m.Receiver.Id == receiverId && m.Sender.Id == senderId) ||
                                        (m.Receiver.Id == senderId && m.Sender.Id == receiverId))
                            .Select(m => new MessageViewModel()
                            {
                                Id = m.Id,
                                Content = m.Content,
                                CreatedOn = m.CreatedOn,
                                Sender = m.Sender.UserName,
                                Receiver = m.Receiver.UserName,
                            })
                            .ToList();
        }

        public IEnumerable<RoomViewModel> GetRooms(string userId)
        {
            var firstHalf = this.data.Messages
                                   .Where(x => x.Receiver.Id == userId)
                                   .Select(x => x.Sender.Id)
                                   .ToHashSet<string>();

            var secondHalf = this.data.Messages
                                   .Where(x => x.Sender.Id == userId)
                                   .Select(x => x.Receiver.Id)
                                   .ToHashSet<string>();

            foreach (var user in firstHalf)
            {
                secondHalf.Add(user);
            }

            var rooms = new HashSet<RoomViewModel>();
            foreach (var user in secondHalf)
            {
                var curr = this.data.Messages
                          .Where(m => (m.Receiver.Id == userId && m.Sender.Id == user) ||
                                  (m.Receiver.Id == user && m.Sender.Id == userId))
                          .OrderByDescending(x => x.CreatedOn)
                          .Select(m => new RoomViewModel()
                          {
                              RoomId = user,
                              LastMessage = m.Content,
                              LastMessageOn = m.CreatedOn,
                              SenderUsername = m.Sender.UserName,
                          })
                          .FirstOrDefault();

                curr.RoomName = this.data.Users
                    .Where(x => x.Id == user)
                    .Select(x => x.UserName)
                    .FirstOrDefault();

                rooms.Add(curr);
            }

            return rooms;
        }
    }
}
