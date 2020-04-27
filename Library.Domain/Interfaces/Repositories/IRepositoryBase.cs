using Dapper;
using System.Collections.Generic;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity GetById(int id);

        TEntity GetById(string text, DynamicParameters param);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(string text);

        bool Update(TEntity entity);

        bool Remove(int id);

        void Dispose();

    }
}
