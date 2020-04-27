using Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Library.Domain.Interfaces.Repositories;
using Library.Infra.Data.Mappings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IConfiguration _configuration;

        protected readonly SqlConnection coonLibrary;

        public RepositoryBase(IConfiguration configuration)
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(config =>
                {
                    #region ENTIDADES | TABELAS

                    config.AddMap(new UserMap());
                    config.AddMap(new RoleMap());
                    config.AddMap(new UserRoleMap());

                    #endregion

                    config.ForDommel();
                });
            }

            _configuration = configuration;

            var configString = _configuration.GetSection("ConnectionStrings:Library").Value;

            coonLibrary = new SqlConnection(configString);
        }


        public virtual TEntity Add(TEntity entity)
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                var id = (int)coonLibrary.Insert(entity);

                entity = GetById(id);

                return entity;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public IEnumerable<TEntity> GetAll(string text)
        {
            IEnumerable<TEntity> ret = null;

            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                var lstEntity = db.Query<TEntity>(text, null, null, false, null, CommandType.Text);
                ret = lstEntity.AsList<TEntity>();
            }

            return ret;
        }

        public TEntity GetById(int id)
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public TEntity GetById(string text, DynamicParameters param)
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                return db.QueryFirst<TEntity>(text, param, null, null, CommandType.Text);
            }

        }

        public bool Remove(int id)
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public bool Update(TEntity entity)
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                return db.Update(entity);
            }
        }


        public void Dispose()
        {
            if (coonLibrary.State == ConnectionState.Open)
            {
                coonLibrary.Close();
                coonLibrary.Dispose();

                GC.SuppressFinalize(this);
            }
        }
    }
}
