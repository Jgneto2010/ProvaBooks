using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add(Category obj)
        {
            _context.Categoryes.Add(obj);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categoryes.ToList();
        }

        public Category GetById(Guid id)
        {
            return _context.Categoryes.Where(c => c.Id == id).First();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpDate(Product obj)
        {
            _context.Products.Update(obj);
        }

        public Task<Category> GetByName(string nomeAplicacao)
        {
            throw new NotImplementedException();
        }

    }
}
