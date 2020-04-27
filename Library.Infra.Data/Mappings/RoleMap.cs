using Dapper.FluentMap.Dommel.Mapping;
using Library.Domain.Entities;

namespace Library.Infra.Data.Mappings
{
    public class RoleMap : DommelEntityMap<Role>
    {
        public RoleMap()
        {
            ToTable("Roles");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.Name).ToColumn("Name");
        }
    }
}
