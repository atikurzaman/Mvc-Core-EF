using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Membership
{    
    public class User:BaseEntity
    {             
        public string ConcurrencyStamp { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }        
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }        
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }        
        public bool IsActive { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
