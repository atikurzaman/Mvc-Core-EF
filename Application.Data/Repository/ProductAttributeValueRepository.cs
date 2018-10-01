using Application.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repository
{
    public class ProductAttributeValueRepository : Repository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(DbContext context) : base(context)
        {
        }
    }
}
