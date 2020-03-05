using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<TResult>> ListAll<TResult>(Expression<Func<Category, TResult>> selector);
    }
}
