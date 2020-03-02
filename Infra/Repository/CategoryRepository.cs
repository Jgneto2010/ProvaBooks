using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, IRepository<Category>, ICategoryRepository
    {
        private readonly Context _context;
        

    }
}
