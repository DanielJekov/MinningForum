namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;
    using MF.Data.Models.Enums;

    public class Reply : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public MFUser Author { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ReplyReaction> ReplyReactions { get; set; }
        = new HashSet<ReplyReaction>();
    }
}
