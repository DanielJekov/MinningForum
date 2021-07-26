namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class TopicsFollowings : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public string FollowerId { get; set; }

        public MFUser Follower { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
