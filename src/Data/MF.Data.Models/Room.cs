namespace MF.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MF.Data.Common.Models;

    public class Room : IAuditInfo
    {
        public int Id { get; set; }

        [Required]
        public string FirstParticipantId { get; set; }

        public MFUser FirstParticipant { get; set; }

        [Required]
        public string SecondParticipantId { get; set; }

        public MFUser SecondParticipant { get; set; }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<UserRooms> Rooms { get; set; }
        = new HashSet<UserRooms>();

        public virtual ICollection<Message> Messages { get; set; }
        = new HashSet<Message>();
    }
}
