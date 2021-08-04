namespace MF.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class Message : IAuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string Content { get; set; }

        [Required]
        public string SenderId { get; set; }

        public MFUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public MFUser Receiver { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
