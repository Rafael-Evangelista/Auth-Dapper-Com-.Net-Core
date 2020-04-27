using Dapper;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
            : base(configuration)
        {
        }

        public IEnumerable<User> GetUserById(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id, System.Data.DbType.Int32);

            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                var sql = $@"SELECT * FROM Users 
                         INNER JOIN UserRoles ON UserRoles.UserId = Users.Id 
                          WHERE Users.Id = @Id";

                var result = db.Query(sql, param).AsList();

                yield return result.Select(user => new User
                {
                    Id = user.Id,
                    Username = user.Username,
                    IsEmailConfirmed = user.IsEmailConfirmed,
                    FullName = user.FullName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserActive = user.UserActive,
                    UserRole = new UserRole
                    {
                        Id = user.Id,
                        UserId = user.UserId,
                        RoleId = user.RoleId
                    }
                }).FirstOrDefault();
            }
        }

        public IEnumerable<User> Login(string username, string password)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@usr", username, System.Data.DbType.String);
            param.Add("@pwd", password, System.Data.DbType.String);

            using (var db = new SqlConnection(coonLibrary.ConnectionString))
            {
                //var qry = "SELECT * FROM Users WHERE Username = @usr AND Password = @pwd AND UserActive = 1";
                //return conn.QueryFirstOrDefault<User>(qry, new { usr = username, pwd = password });

                var sql = $@"  SELECT * FROM Users 
                         INNER JOIN UserRoles ON UserRoles.UserId = Users.Id 
						 WHERE Username = @usr AND Password = @pwd AND UserActive = 1";

                var result = db.Query(sql, param).AsList();

                var user = new User();
                var userRole = new UserRole();

                var teste = result.Select(a => a.GetTypes()).Where(t => t.Id == user.Id && t.Username == user.Username && t.UserRole.UserId == user.Id);

                return teste.First();


                //yield return result.Select(user => new User
                //{
                //    Id = user.Id,
                //    Username = user.Username,
                //    IsEmailConfirmed = user.IsEmailConfirmed,
                //    FullName = user.FullName,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    PhoneNumber = user.PhoneNumber,
                //    UserActive = user.UserActive,
                //    UserRole = new UserRole
                //    {
                //        Id = user.Id,
                //        UserId = user.UserId,
                //        RoleId = user.RoleId
                //    }
                //}).FirstOrDefault();



            }
        }

    }
}
