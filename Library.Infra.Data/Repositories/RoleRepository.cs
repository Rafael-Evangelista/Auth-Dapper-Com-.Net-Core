using Dapper;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Library.Infra.Data.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IConfiguration configuration)
               : base(configuration)
        {
        }
    }
}
