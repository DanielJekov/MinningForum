namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReportProcessData
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string  ReportedUserInfo { get; set; }

        [Required]
        public string ProccesorId { get; set; }

        public MFUser Proccesor { get; set; }

        public DateTime ProcessedDate { get; set; }
        = DateTime.UtcNow;

        public virtual ICollection<BanData> BansData { get; set; }
        = new HashSet<BanData>();

        public virtual ICollection<ReplyReport> ReplyReports { get; set; }
        = new HashSet<ReplyReport>();

        public virtual ICollection<TopicReport> TopicReports { get; set; }
         = new HashSet<TopicReport>();
    }
}
