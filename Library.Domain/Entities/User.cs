using Library.Domain.Entities;

namespace Library.Domain.DTO
{
    public partial class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool UserActive { get; set; }
        public UserRole UserRole { get; set; }




    }
}
