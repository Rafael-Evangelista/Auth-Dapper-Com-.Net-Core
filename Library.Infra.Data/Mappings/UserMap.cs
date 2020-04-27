using Dapper.FluentMap.Dommel.Mapping;
using Library.Domain.DTO;

namespace Library.Infra.Data.Mappings
{
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap()
        {
            ToTable("Users");
            Map(x => x.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(x => x.Username).ToColumn("Username");
            Map(x => x.Password).ToColumn("Password");
            Map(x => x.IsEmailConfirmed).ToColumn("IsEmailConfirmed");
            Map(x => x.FullName).ToColumn("FullName");
            Map(x => x.FirstName).ToColumn("FirstName");
            Map(x => x.LastName).ToColumn("LastName");
            Map(x => x.Email).ToColumn("Email");
            Map(x => x.PhoneNumber).ToColumn("PhoneNumber");
            Map(x => x.UserActive).ToColumn("UserActive");
            Map(x => x.UserRole).Ignore();
        }
    }
}
