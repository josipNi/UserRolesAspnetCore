using System.Collections.Generic;

namespace UserTable.Server.Models
{
    public class ApplicationUserVM
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserRolesVM> UserRoles { get; set; }
    }

    public class UserRolesVM
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}