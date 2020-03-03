using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>  
        where T : Entity
    {
        ValueTask<EntityEntry<T>> Add(T obj);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void UpDate(T obj);
        void Remove(Guid id);
        Task<int> SaveChanges();
    }
}
