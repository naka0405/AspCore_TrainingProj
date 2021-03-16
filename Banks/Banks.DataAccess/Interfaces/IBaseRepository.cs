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
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity item);
        Task<TEntity> GetById(int id);
        Task Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task<int> SaveChanges();
    }
}
