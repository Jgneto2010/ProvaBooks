using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> 
        where T : Entity
    {
        private Context context;

        protected RepositoryBase(Context context)
        {
            this.context = context;
        }

        public void Add(T obj)
        {
            throw new NotImplementedException();
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

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpDate(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
