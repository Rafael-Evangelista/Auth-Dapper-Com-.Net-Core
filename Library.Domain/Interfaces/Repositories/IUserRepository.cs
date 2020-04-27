using Library.Domain.DTO;
using System.Collections.Generic;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> Login(string username, string password);
        IEnumerable<User> GetUserById(int id);
    }
}
