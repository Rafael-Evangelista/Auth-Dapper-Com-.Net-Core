using System.Collections.Generic;

namespace Library.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(int id);

        void Dispose();
    }
}
