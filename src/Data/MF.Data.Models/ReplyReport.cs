namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReplyReport
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        [Required]
        public string ReportingUserId { get; set; }

        public MFUser ReportingUser { get; set; }

        public int? ReportProcessDataId { get; set; }

        public ReportProcessData ReportProcessData { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;
    }
}
