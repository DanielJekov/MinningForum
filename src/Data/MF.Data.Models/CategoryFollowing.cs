namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class CategoryFollowing : IAuditInfo
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string FollowerId { get; set; }

        public MFUser Follower { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
