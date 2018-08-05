using System;
using System.Collections.Generic;

namespace Application.Domain.Membership
{
    public class Role:BaseEntity
    {
        public string ConcurrencyStamp { get;set;}
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
