namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class Reply : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public MFUser Author { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public int? QuoteReplyId { get; set; }

        public Reply QuoteReply { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ReplyReaction> ReplyReactions { get; set; }
        = new HashSet<ReplyReaction>();

        public virtual ICollection<ReplyReport> ReplyReports { get; set; }
        = new HashSet<ReplyReport>();
    }
}
