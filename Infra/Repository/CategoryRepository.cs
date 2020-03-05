using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, IRepository<Category>, ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context) : base(context)
        {
            _context = context;
        }

        public Task<List<TResult>> ListAll<TResult>(Expression<Func<Category, TResult>> selector)
        {
            return DbSet.Select(selector).ToListAsync();
        }
    }
}
