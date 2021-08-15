namespace MF.Web.Controllers
{
    using MF.Services.Users;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Profile(string userId)
        {
            var currUserId = this.GetUserId();
            var user = this.usersService.Profile(currUserId, userId);

            return this.View(user);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Follow(string userId)
        {
            var followerId = this.GetUserId();
            var isFollower = this.usersService.IsFollower(followerId, userId);
            if (userId == followerId || isFollower)
            {
                return this.BadRequest();
            }

            this.usersService.AddFollower(followerId, userId);

            return this.RedirectToAction(nameof(this.Profile), new { userId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Unfollow(string userId)
        {
            var followerId = this.GetUserId();
            var isFollower = this.usersService.IsFollower(followerId, userId);
            if (userId == followerId || !isFollower)
            {
                return this.BadRequest();
            }

            this.usersService.RemoveFollower(followerId, userId);

            return this.RedirectToAction(nameof(this.Profile), new { userId });
        }
    }
}
