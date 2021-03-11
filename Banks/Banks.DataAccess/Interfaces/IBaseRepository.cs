using Banks.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    public interface IBaseRepository<TEntity>
         where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
        void Delete(TEntity item);
        Task<TEntity> GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task SaveChanges();
    }
}
