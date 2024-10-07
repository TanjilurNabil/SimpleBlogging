using Microsoft.EntityFrameworkCore;
using SimpleBlogging.Application.Interfaces;
using SimpleBlogging.Domain.Entities;
using SimpleBlogging.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogging.Infrastructure.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.Include(x=>x.Categories).AsNoTracking().ToListAsync();
        }
    }
}
