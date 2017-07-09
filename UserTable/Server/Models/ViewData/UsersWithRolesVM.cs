using System.Collections.Generic;

namespace UserTable.Server.Models.ViewData
{
    public class UsersWithRolesVM
    {
        public IEnumerable<ApplicationUserVM> Users_list { get; set; }
        public IEnumerable<IdentityRoleVM> Roles_list { get; set; }
        public string RoleNames { get; set; }
    }
}