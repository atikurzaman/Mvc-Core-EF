using Application.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repository
{
    public class AttributeValueRepository : Repository<AttributeValue>, IAttributeValueRepository
    {
        public AttributeValueRepository(DbContext context) : base(context)
        {
        }
    }
}
