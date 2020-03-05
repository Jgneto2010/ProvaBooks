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
using static Infra.Contexto.Context;

namespace Infra.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IRepository<Product>, IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }
        public Task<List<TResult>> ListAll<TResult>(Expression<Func<Product, TResult>> selector)
        {
            return DbSet.Select(selector).ToListAsync();
        }
        public Task<Product> Buscar(Guid id)
        {
            return DbSet.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
             
        }
        
    }
       
    
}
