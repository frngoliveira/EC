using System;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task Add(TEntity obj)
        {
            await _repository.Add(obj);
        }      

        public async Task<List<TEntity>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Remove(TEntity obj)
        {
            await _repository.Remove(obj);
        }

        public async Task Update(TEntity obj)
        {
            await _repository.Update(obj);
        }
        
    }
}