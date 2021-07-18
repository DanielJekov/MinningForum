namespace MF.Data.Models
{
    using System;

    using MF.Data.Common.Models;
    using MF.Data.Models.Enums;

    public class TopicReaction : IAuditInfo
    {
        public int Id { get; set; }

        public ReactionType ReactionType { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public string AuthorId { get; set; }

        public MFUser Author { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }
    }
}
