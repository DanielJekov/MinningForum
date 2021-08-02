namespace MF.Services.Users
{
    public interface IUsersService
    {
        public void Details();

        public void AddFollower(string followerId, string followedId);

        public void RemoveFollower(string followerId, string followedId);
    }
}
