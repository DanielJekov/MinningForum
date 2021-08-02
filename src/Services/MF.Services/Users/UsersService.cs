namespace MF.Services.Users
{
    using MF.Data;
    using MF.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly MFDbContext data;

        public UsersService(MFDbContext data)
        {
            this.data = data;
        }

        public void AddFollower(string followerId, string followedId)
        {
            var userFollower = new UserFollower() { FollowedUserId = followedId, FollowerUserId = followerId };
            this.data.UserFollowers.Add(userFollower);
        }

        public void RemoveFollower(string followerId, string followedId)
        {
            var userFollower = new UserFollower() { FollowedUserId = followedId, FollowerUserId = followerId };
            this.data.UserFollowers.Add(userFollower);
        }

        public void Details()
        {
            throw new System.NotImplementedException();
        }
    }
}
