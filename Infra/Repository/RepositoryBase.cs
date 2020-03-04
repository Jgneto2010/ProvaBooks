using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> 
        where T : Entity
    {
        private Context context;
        protected readonly DbSet<T> DbSet;

        protected RepositoryBase(Context context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public async Task Remove(Guid id)
        {
            var product = await GetById(id);
            DbSet.Remove(product);
        }

        public ValueTask<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>> Add(T obj)
        {
            return DbSet.AddAsync(obj);
        }
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
        public Task<T> GetById(Guid id)
        {
            return DbSet.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public virtual void UpDate(T obj)
        {
            DbSet.Update(obj);
        }
        
    }
}
