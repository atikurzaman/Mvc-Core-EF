using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Membership
{    
    public class UserRole
    {   
        public Int64 UserId { get; set; }
        public User User { get; set; }
        public Int64 RoleId { get; set; }
        public Role Role { get; set; }        
    }
}
