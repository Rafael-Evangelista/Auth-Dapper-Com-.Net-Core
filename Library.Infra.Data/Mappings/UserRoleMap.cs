using Dapper.FluentMap.Dommel.Mapping;
using Library.Domain.Entities;

namespace Library.Infra.Data.Mappings
{
    public class UserRoleMap : DommelEntityMap<UserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRoles");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.UserId).ToColumn("UserId");
            Map(x => x.RoleId).ToColumn("RoleId");
            Map(x => x.User).Ignore();
            Map(x => x.Role).Ignore();
        }
    }
}
