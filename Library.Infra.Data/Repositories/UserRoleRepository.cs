using Dapper;
using Dommel;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Infra.Data.Repositories
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IConfiguration configuration)
               : base(configuration)
        {
        }

        public override IEnumerable<UserRole> GetAll()
        {
            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                return coonLibrary.GetAll<UserRole, User, UserRole>((userRole, user) =>
                {
                    userRole.User = user;
                    return userRole;
                });
            }
        }
    }
}
