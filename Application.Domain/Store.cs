using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class Store:BaseEntity
    {
        public string Name { get; set; }        
        public Boolean IsActive { get; set; }
    }
}
