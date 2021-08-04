namespace MF.Web.Controllers
{
    using MF.Data;
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
        public IActionResult New()
        {
            var users = this.messagesService.GetAllUsers();

            return this.View(users);
        }

        [Authorize]
        [HttpPost]
        public IActionResult New(string receiverId, string message)
        {
            var senderId = this.GetUserId();
            this.messagesService.New(senderId, receiverId, message);

            return this.RedirectToAction(nameof(PrivateChat), new { receiverId = receiverId });
        }

        [Authorize]
        public IActionResult PrivateChat(string receiverId)
        {

            var senderId = this.GetUserId();
            var messages = this.messagesService.MessagesBetweenUsers(senderId, receiverId);
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
            var rooms = this.messagesService.GetRooms(userId);

            return this.View(rooms);
        }
    }
}
