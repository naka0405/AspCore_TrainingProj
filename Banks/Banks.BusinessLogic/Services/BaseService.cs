using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess;
using Banks.Entities.Entities;
using Banks.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    public class BaseService<TEntity, TView, C> : IBaseService<TView, C>
        where TEntity : BaseEntity
        where TView : BaseViewModel, new() 
        where C:CollectionBaseVM<TView>, new()
    {
        protected readonly IBaseRepository<TEntity> repository;
        protected readonly IMapper mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual async Task<TView> GetById(int id)
        {
            TEntity entity = await repository.GetById(id);

            return entity != null ? mapper.Map<TView>(entity) : null;
        }

        public virtual C GetAll()
        {
            var entities = repository.GetAll();
            if (entities==null)
            {
                return new C();
            }           
            CollectionBaseVM<TView> collectionVM = new C();
            collectionVM.Collection = mapper.Map<List<TView>>(entities);
            return (C)collectionVM;
        }

        public virtual C GetAll(TView conditions)
        {
            var mappedConditions = mapper.Map<TEntity>(conditions);
            var entities = repository.GetAll(x => x.Id == mappedConditions.Id);
            if(entities==null)
            {
                return new C();
            }
            CollectionBaseVM<TView> collectionVM = new C();
            collectionVM.Collection = mapper.Map<List<TView>>(entities);
            return (C)collectionVM;
        }

        public virtual async Task Delete(TView model)
        {
            var entityForDelete = await repository.GetById(model.Id);
            if (entityForDelete == null)
            {
                throw new ArgumentException("Cannot get null entity.");
            }
            try
            {
                repository.Delete(entityForDelete);
            }
            catch
            {
                throw new ArgumentException("Something went wrong!");
            }
            await repository.SaveChanges();            
        }

       
        public virtual async Task<int> Create(TView model)
        {
            var entity = mapper.Map<TEntity>(model);
            try 
            {
                await repository.Insert(entity);
            }
            catch
            {
                throw new ArgumentException("Something went wrong!");
            }   
            return await repository.SaveChanges();
        }

        public virtual async Task Update(TView model)
        {
            var dataForUpdate = mapper.Map<TEntity>(model);
            try
            {
                repository.Update(dataForUpdate);
            }
            catch
            {
                throw new ArgumentException("Something went wrong!");
            }            
            await repository.SaveChanges();
        }

        public void Dispose()
        {
            if (repository == null)
            {
                return;
            }
            if (repository is IDisposable)
            {
                repository.Dispose();
            }
        }
    }
}
