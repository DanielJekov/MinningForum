namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TopicReport
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ReportingUserId { get; set; }

        public MFUser ReportingUser { get; set; }

        public int? ReportProcessDataId { get; set; }

        public ReportProcessData ReportProcessData { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;
    }
}
