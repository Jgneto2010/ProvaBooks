using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        ValueTask<EntityEntry<T>> Add(T obj);
        Task<T> GetById(Guid id);
        IEnumerable<T> GetAll();
        Task Remove(Guid id);
        Task<int> SaveChanges();
        void UpDate(T obj);

    }
}
