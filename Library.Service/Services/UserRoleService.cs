using Dapper;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Service.Services
{
    public class UserRoleService : ServiceBase<UserRole>, IUserRoleService
    {
        public readonly IUserRoleRepository _repository;

        public readonly IConfiguration _configuration;

        public UserRoleService(IRepositoryBase<UserRole> repositoryBase, IUserRoleRepository repository, IConfiguration configuration)
            : base(repositoryBase)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public virtual IEnumerable<UserRole> GetAll()
        {
            const string sql = "SELECT * FROM UserRoles INNER JOIN Users ON UserRoles.UserId = Users.Id; ";

            var configString = _configuration.GetSection("ConnectionStrings:Library").Value;

            using (var db = new SqlConnection(configString))
            {
                var result = db.Query(sql);

                return result.Select(userRole => new UserRole
                {
                    Id = userRole.Id,
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId,
                    User = new User
                    {
                        Id = userRole.Id,
                        Username = userRole.Username,
                        IsEmailConfirmed = userRole.IsEmailConfirmed,
                        FullName = userRole.FullName,
                        FirstName = userRole.FirstName,
                        LastName = userRole.LastName,
                        Email = userRole.Email,
                        PhoneNumber = userRole.PhoneNumber,
                        UserActive = userRole.UserActive
                    }
                });
            }
        }
    }

}

