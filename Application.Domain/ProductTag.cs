using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain
{
    public class ProductTag
    {
        public Int64 ProductId { get; set; }
        public Product Product { get; set; }
        public Int64 TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
