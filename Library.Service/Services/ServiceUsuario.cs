using Library.Domain.DTO;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using System;

namespace Library.Service.Services
{
    public class ServiceUsuario<TEntity> : IDisposable, IServiceUsuario<TEntity> where TEntity : class
    {
        private readonly IRepositoryUsuario<TEntity> _repository;

        public ServiceUsuario(IRepositoryUsuario<TEntity> repository)
        {
            _repository = repository;
        }

        public User Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
