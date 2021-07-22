namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class Category : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public MFUser Author { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Topic> Topics { get; set; }
        = new HashSet<Topic>();
    }
}
