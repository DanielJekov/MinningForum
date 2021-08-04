namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class TopicReport : IAuditInfo
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int? TopicId { get; set; }

        public Topic Topic { get; set; }

        [Required]
        public string ReportingUserId { get; set; }

        public MFUser ReportingUser { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }
    }
}
