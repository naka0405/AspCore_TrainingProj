using Banks.Entities.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    public interface IBaseRepository<TEntity> : IDisposable
         where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
        EntityEntry<TEntity> Delete(TEntity item);
        Task<TEntity> GetById(int id);
        EntityEntry<TEntity> Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task<int> SaveChanges();
    }
}
