namespace MF.Services.Users
{
    using MF.Models.ViewModels.Users;

    public interface IUsersService
    {
        public UserProfileViewModel Profile(string currUserId, string userId);

        public bool IsExist(string userId);

        public void AddFollower(string followerId, string followedId);

        public void RemoveFollower(string followerId, string followedId);

        public bool IsFollower(string followerId, string followedId);

        public int FollowersCount(string userId);
    }
}
