namespace MF.Data.Models
{
    using System;

    using MF.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class MFRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public MFRole()
          : this(null)
        {
        }

        public MFRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }
        = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
