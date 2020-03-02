using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using static Infra.Contexto.Context;

namespace Infra.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IRepository<Product>, IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context) : base(context)
        {
            _Context = contexto;
        }

    }
       
    
}
