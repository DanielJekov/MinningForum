namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MF.Data.Common.Models;
    using MF.Data.Models.Enums;

    public class ReplyReaction : IAuditInfo
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int ReplyId { get; set; }

        public Reply Reply { get; set; }

        public string AuthorId { get; set; }

        public MFUser Author { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

    }
}
