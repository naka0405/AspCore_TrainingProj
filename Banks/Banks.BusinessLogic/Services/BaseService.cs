﻿using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess;
using Banks.Entities.Entities;
using Banks.ViewModels.Models;
using Banks.ViewModels.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    /// <summary>       
    /// Base service class with general methods to manipulate entities
    /// </summary>
    public class BaseService<TEntity>: IBaseService<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly IBaseRepository<TEntity> repository;
        protected readonly IMapper mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>       
        /// Get account bu Id
        /// </summary>
        public virtual async Task<TView> GetById<TView>(int id) where TView:BaseViewModel
        {
            TEntity entity = await repository.GetById(id);           
            var viewModel = mapper.Map <TEntity, TView> (entity);
            return viewModel;
        }

        /// <summary>       
        /// Get all accounts from db for selecting in specific services
        /// </summary>
        protected virtual async Task<List<TView>> GetAll<TView>() 
        {
            var entities =await repository.GetAll();
            var collectionVM = new List<TView>();
            if (entities == null)
            {
                return collectionVM;
            }
            collectionVM = mapper.Map<List<TView>>(entities);
            return collectionVM;
        }

        /// <summary>       
        /// Get all accounts by bankId, clientCode
        /// </summary>
        public virtual async Task Delete<TView>(TView model) where TView : BaseViewModel
        {
            var entity = await repository.GetById(model.Id);
                     
            if (entity == null)
            {
                throw new ArgumentException("Cannot delete null entity.");
            }
            var entityForDelete = this.mapper.Map<TView, TEntity>(model,entity);
            repository.Delete(entityForDelete);
            await repository.SaveChanges();
        }

        /// <summary>       
        /// Map viewModel from api to entity and insert it in the db
        /// </summary>
        public virtual async Task<int> Create<TView>(TView model) where TView : BaseViewModel
        {
            var entity = mapper.Map<TEntity>(model);
            await repository.Insert(entity);
            await repository.SaveChanges();
            return entity.Id;
        }

        /// <summary>       
        /// Get entity for update from db, try update using map viewmodel on it
        /// </summary>
        public virtual async Task Update<TView>(TView model) where TView : BaseViewModel
        {
            var entity =await repository.GetById(model.Id);
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
