namespace MF.Web.Controllers
{
    using System.Linq;

    using MF.Data;
    using MF.Models.ViewModels;
    using MF.Services.Messages;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : BaseController
    {
        private readonly IMessagesService messagesService;
        private readonly MFDbContext data;

        public MessagesController(
            IMessagesService messagesService,
            MFDbContext data)
        {
            this.messagesService = messagesService;
            this.data = data;
        }

        [Authorize]
        public IActionResult Chat()
        {
            var userId = this.GetUserId();
            var chatMembers = this.messagesService.GetChatMembers(userId);

            return this.View(chatMembers);
        }

        [Authorize]
        public IActionResult PrivateChat(string receiverId)
        {
            if (!this.data.Users.Any(x => x.Id == receiverId) ||
                !this.data.Users.Any(x => x.MessageOutbox.Any(x => x.Receiver.Id == receiverId) ||
                !this.data.Users.Any(x => x.MessageInbox.Any(x => x.Receiver.Id == receiverId))))
            {
                return this.Redirect("/Messages/New/");
            }

            var senderId = this.GetUserId();
            var messages = this.messagesService.AllBetweenUsers(senderId, receiverId);
            foreach (var msg in messages)
            {
                msg.CurrUser = this.data.Users.Find(senderId).UserName;
            }

            this.ViewBag.UserId = senderId;
            return this.View(messages);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PrivateChat(string receiverId, string message)
        {
            var senderId = this.GetUserId();
            this.messagesService.New(senderId, receiverId, message);
            return this.Redirect("/Messages/PrivateChat/?receiverId=" + receiverId + "#message");
        }

        [Authorize]
        public IActionResult Rooms()
        {
            var userId = this.GetUserId();
            var rooms = this.messagesService.Rooms(userId);
            return this.View(rooms);
        }

        [Authorize]
        public IActionResult New()
        {
            var users = this.data.Users
                .Select(u => new UserViewModel
                {
                    ReceiverId = u.Id,
                    Username = u.UserName,
                })
                .ToList();

            return this.View(users);
        }

        [Authorize]
        [HttpPost]
        public IActionResult New(string receiverId, string message)
        {
            var senderId = this.GetUserId();
            this.messagesService.New(senderId, receiverId, message);

            return this.Redirect("/Messages/Rooms/");
        }
    }
}
