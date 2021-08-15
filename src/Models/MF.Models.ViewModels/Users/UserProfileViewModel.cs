namespace MF.Models.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool IsFollowed { get; set; }

        public DateTime JoinDate { get; set; }

        public DateTime LastActivity { get; set; }

        public string Gender { get; set; }

        public string Location { get; set; }

        public ICollection<string> Followings { get; set; }

        public int RepliesCount { get; set; }

        public int FollowersCount { get; set; }

        public int ReactionsCount { get; set; }
    }
}
