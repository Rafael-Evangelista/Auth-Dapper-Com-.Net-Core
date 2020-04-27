using Library.Domain.DTO;

namespace Library.Domain.Interfaces.Services
{
    public interface IServiceUsuario<TEntity> where TEntity : class
    {
        User Login(string username, string password);
    }
}
