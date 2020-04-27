using Library.Domain.DTO;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Library.Service.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public readonly IUserRepository _repository;

        public UserService(IRepositoryBase<User> repositoryBase, IUserRepository repository)
            : base(repositoryBase)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public IEnumerable<User> Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

    }
}
