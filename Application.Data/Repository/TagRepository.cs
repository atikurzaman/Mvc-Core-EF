using Application.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repository
{
    public class TagRepository: Repository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}
