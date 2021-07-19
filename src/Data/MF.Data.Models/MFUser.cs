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

        public bool IsBanned { get; set; }

        public BanData BanData { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<MFUser> FollowedUsers { get; set; }
        = new HashSet<MFUser>();

        public virtual ICollection<BanData> Bans { get; set; }
        = new HashSet<BanData>();

        public virtual ICollection<Topic> FollowedTopics { get; set; }
         = new HashSet<Topic>();

        public virtual ICollection<Topic> Topics { get; set; }
         = new HashSet<Topic>();

        public virtual ICollection<Reply> Replies { get; set; }
        = new HashSet<Reply>();

        public virtual ICollection<Category> Categories { get; set; }
        = new HashSet<Category>();

        public virtual ICollection<Category> FollowedCategories { get; set; }
         = new HashSet<Category>();

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        = new HashSet<IdentityUserLogin<string>>();
    }
}
