namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class TopicFollower : IAuditInfo
    {
        public int Id { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public string FollowerId { get; set; }

        public MFUser Follower { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }
    }
}
