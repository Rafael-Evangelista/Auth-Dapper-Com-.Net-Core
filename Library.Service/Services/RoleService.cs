using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;

namespace Library.Service.Services
{
    public class RoleService : ServiceBase<Role>, IRoleService
    {
        public readonly IRoleRepository _repository;

        public RoleService(IRepositoryBase<Role> repositoryBase, IRoleRepository repository)
            : base(repositoryBase)
        {
            _repository = repository;
        }
    }
}
