using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Infra.Data.Repositories;
using Library.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            #endregion

            #region Services
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

        }
    }
}
