namespace MF.Services.Users
{
    using System.Linq;

    using MF.Data;
    using MF.Data.Models;
    using MF.Models.ViewModels.Users;

    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly MFDbContext data;

        public UsersService(MFDbContext data)
        {
            this.data = data;
        }

        public UserProfileViewModel Profile(string currUserId, string userId)
        {
            var temp = this.data.Users
                 .Where(u => u.Id == userId)
                 .Include(u => u.Followers)
                 .Select(u => new UserProfileViewModel()
                 {
                     Id = u.Id,
                     Username = u.UserName,
                     Gender = u.GenderType.ToString(),
                     JoinDate = u.CreatedOn,
                     LastActivity = u.Replies.Where(r => r.IsDeleted == false)
                                             .OrderByDescending(r => r.CreatedOn)
                                             .Select(r => r.CreatedOn)
                                             .FirstOrDefault(),
                     Location = "Varna",
                     RepliesCount = u.Replies.Count,
                     ReactionsCount = u.ReplyReactions.Count + u.TopicReactions.Count,
                 })
                 .FirstOrDefault();

            temp.FollowersCount = this.data.Users
                                           .Include(x => x.Followers)
                                           .ToList()
                                           .Sum(x => x.Followers
                                                      .Where(s => s.FollowedUser.Id == userId)
                                           .Count());

            temp.IsFollowed = this.data.Users
                                       .Where(x => x.Id == currUserId)
                                       .Select(x => x.Followers.Any(s => s.FollowerUser.Id == currUserId && s.FollowedUser.Id == userId))
                                       .FirstOrDefault();

            return temp;
        }

        public bool IsExist(string userId)
        {
            return this.data.Users
                            .Where(u => u.IsDeleted == false)
                            .Any(u => u.Id == userId);
        }

        public void AddFollower(string followerId, string followedId)
        {
            var userFollower = new UserFollower() { FollowedUserId = followedId, FollowerUserId = followerId };
            this.data.UserFollowers.Add(userFollower);
            this.data.SaveChanges();
        }

        public void RemoveFollower(string followerId, string followedId)
        {
            var userFollower = this.data.UserFollowers
                .FirstOrDefault(x => x.FollowerUser.Id == followerId &&
                                     x.FollowedUser.Id == followedId);
            this.data.UserFollowers.Remove(userFollower);
            this.data.SaveChanges();
        }

        public bool IsFollower(string followerId, string followedId)
        {
            return this.data.UserFollowers
                            .Any(x => x.FollowerUser.Id == followerId &&
                                      x.FollowedUser.Id == followedId);
        }

        public int FollowersCount(string userId)
        {
            return this.data.Users
                            .Where(x => x.Id == userId)
                            .Select(x => x.Followers.Count)
                            .FirstOrDefault();
        }
    }
}
