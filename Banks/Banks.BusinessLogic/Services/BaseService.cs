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
    /// <summary>       
    /// Base service class with functionality to work with entities.
    /// </summary>
    ///  /// <summary>       
    /// TEntity is generic parametr for entity.         
    /// </summary>
    public class BaseService<TEntity>: IBaseService<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly IBaseRepository<TEntity> repository;
        protected readonly IMapper mapper;

        /// <summary>
        /// Has generic repository and mapper injection.
        /// </summary>       
        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>       
        /// Get account by Id.
        /// </summary>
        public virtual async Task<TView> GetById<TView>(int id) where TView:BaseViewModel
        {            
            TEntity entity = await repository.GetById(id);  
            if(entity==null)
            {
                throw new ArgumentException("Such entity not found!");
            }
            var viewModel = mapper.Map <TEntity, TView> (entity);
            return viewModel;
        }

        /// <summary>       
        /// Get all accounts for selecting in specific services.
        /// </summary>
        protected virtual async Task<List<TView>> GetAll<TView>() 
        {
            var entities =await repository.GetAll();
            var collectionVM = new List<TView>();
            if (entities == null)
            {
                return collectionVM;
            }           
            collectionVM=  mapper.Map<List<TView>>(entities);
            return collectionVM;
        }

        /// <summary>       
        /// Delete entity method.
        /// </summary>
        public virtual async Task Delete(int id)
        {
            var entity = await repository.GetById(id);
                     
            if (entity == null)
            {
                throw new ArgumentException("Cannot delete null entity.");
            }
            repository.Delete(entity);
            await repository.SaveChanges();
        }

        /// <summary>       
        /// Method for create entity.
        /// </summary>
        public virtual async Task<int> Create<TView>(TView model) where TView : BaseViewModel
        {            
            var entity = mapper.Map<TEntity>(model);
            await repository.Insert(entity);
            await repository.SaveChanges();
            return entity.Id;
        }

        /// <summary>       
        /// Method for update entity.
        /// </summary>
        public virtual async Task Update<TView>(TView model) where TView : BaseViewModel
        {
            var entity = await repository.GetById(model.Id);
            if (entity == null)
            {
                throw new ArgumentException("Such entity not found!");
            }
            var dataForUpdate = mapper.Map<TView, TEntity>(model, entity);            
            repository.Update(dataForUpdate);
            await repository.SaveChanges();
        }

        /// <summary>       
        /// Disposing injected repository if that need
        /// </summary>
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
