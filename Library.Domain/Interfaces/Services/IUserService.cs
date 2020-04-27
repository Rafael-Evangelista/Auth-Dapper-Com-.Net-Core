using Library.Domain.DTO;
using System.Collections.Generic;

namespace Library.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        IEnumerable<User> Login(string username, string password);
        IEnumerable<User> GetUserById(int id);
    }
}
