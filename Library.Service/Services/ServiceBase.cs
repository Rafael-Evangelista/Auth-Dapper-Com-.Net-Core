using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Library.Service.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
