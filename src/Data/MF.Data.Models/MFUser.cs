namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MF.Data.Common.Models;
    using MF.Data.Models.Enums;

    using Microsoft.AspNetCore.Identity;

    public class MFUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public MFUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public GenderType GenderType { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Message> MessageInbox { get; set; }
        = new HashSet<Message>();

        public virtual ICollection<Message> MessageOutbox { get; set; }
        = new HashSet<Message>();

        public virtual ICollection<UserFollower> Followers { get; set; }
        = new HashSet<UserFollower>();

        public virtual ICollection<Category> Categories { get; set; }
        = new HashSet<Category>();

        public virtual ICollection<CategoryFollower> FollowedCategories { get; set; }
        = new HashSet<CategoryFollower>();

        public virtual ICollection<Topic> Topics { get; set; }
         = new HashSet<Topic>();

        public virtual ICollection<TopicFollower> FollowedTopics { get; set; }
         = new HashSet<TopicFollower>();

        public virtual ICollection<TopicReaction> TopicReactions { get; set; }
        = new HashSet<TopicReaction>();

        public virtual ICollection<TopicReport> TopicReports { get; set; }
        = new HashSet<TopicReport>();

        public virtual ICollection<Reply> Replies { get; set; }
        = new HashSet<Reply>();

        public virtual ICollection<ReplyReaction> ReplyReactions { get; set; }
        = new HashSet<ReplyReaction>();

        public virtual ICollection<ReplyReport> ReplyReports { get; set; }
        = new HashSet<ReplyReport>();

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        = new HashSet<IdentityUserLogin<string>>();
    }
}
