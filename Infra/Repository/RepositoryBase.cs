using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpDate(T obj)
        {
            throw new NotImplementedException();
        }
        public ValueTask<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>> Add(T obj)
        {
            return DbSet.AddAsync(obj);
        }
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
