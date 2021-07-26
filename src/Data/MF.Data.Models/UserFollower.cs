namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class UserFollower : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string FollowedUserId { get; set; }

        public MFUser FollowedUser { get; set; }

        [Required]
        public string FollowerUserId { get; set; }

        public MFUser FollowerUser { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
