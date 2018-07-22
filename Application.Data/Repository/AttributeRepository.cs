using Application.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repository
{
    public class AttributeRepository : Repository<Domain.Attribute>, IAttributeRepository
    {
        public AttributeRepository(DbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}
