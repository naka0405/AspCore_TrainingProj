﻿using Banks.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banks.DataAccess
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : BaseEntity
    {
        protected ApplicationContext appContext;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            appContext = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual EntityEntry<TEntity> Delete(TEntity entityToDelete)
        {
            return dbSet.Remove(entityToDelete);
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual EntityEntry<TEntity> Insert(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            appContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task<int> SaveChanges()
        {
            return await appContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate);
        }

        public void Dispose()
        {
            appContext.Dispose();
        }
    }
}