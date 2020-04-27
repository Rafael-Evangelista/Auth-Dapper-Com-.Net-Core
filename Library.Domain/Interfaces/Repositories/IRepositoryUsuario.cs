using Library.Domain.DTO;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario<TEntity> where TEntity : class
    {
        User Login(string username, string password);

        void Dispose();
    }
}
