using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Product obj)
        {
            _context.Products.Add(obj);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _context.Products.Where(c => c.Id == id).First();
        }

        public Product ObterProdutoPeloNome(string name)
        {
            return _context.Products.Where(c => c.Name == name).First();
        }

        public Product ObterPeloId(Guid id)
        {
            throw new NotImplementedException();
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpDate(Product obj)
        {
            _context.Products.Update(obj);
        }

        public Task<Product> GetByName(string nomeAplicacao)
        {
            throw new NotImplementedException();
        }

    }
       
    
}
