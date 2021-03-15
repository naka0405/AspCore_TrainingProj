using AutoMapper;
using Banks.BusinessLogic.Interfaces;
using Banks.DataAccess;
using Banks.Entities.Entities;
using Banks.ViewModels.Enums;
using Banks.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banks.BusinessLogic.Services
{
    public class BaseService<TEntity, TView> : IBaseService<TView>
        where TEntity : BaseEntity
        where TView : BaseViewModel
    {
        private readonly IBaseRepository<TEntity> repository;
        private readonly IMapper mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<TView> GetById(int id)
        {
            TEntity entity = await repository.GetById(id);

            return entity != null ? mapper.Map<TView>(entity) : null;
        }

        public List<TView> GetAll()
        {
            var entities = repository.GetAll().ToList();
            return mapper.Map<List<TView>>(entities);
        }

        public List<TView> GetAll(TView conditions)
        {
            var mappedPredicate = mapper.Map<TEntity>(conditions);
            var entities = repository.GetAll(x => x.Id == mappedPredicate.Id);
            return entities != null ? mapper.Map<List<TView>>(entities).ToList() : null;
        }

        public async Task<bool> Delete(TView model)
        {
            var entityForDelete = await repository.GetById(model.Id);
            if (entityForDelete == null)
            {
                return false;
            }
            if (repository.Delete(entityForDelete) == null)
            {
                return false;
            }
            await repository.SaveChanges();
            return true;
        }

       
        public async Task<SaveResults> Save(TView model)
        {
            var entity = mapper.Map<TEntity>(model);
            var entry = repository.Insert(entity);
            if (entry != null)
            {
                await repository.SaveChanges();
                return SaveResults.Ok;
            }
            return SaveResults.ServerError;
        }

        public async Task<SaveResults> Update(TView model)
        {
            var dataForUpdate = mapper.Map<TEntity>(model);
            repository.Update(dataForUpdate);
            var result= await repository.SaveChanges();
            if(result>0)
            {
                return SaveResults.Ok;
            }
            return SaveResults.ServerError;
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
