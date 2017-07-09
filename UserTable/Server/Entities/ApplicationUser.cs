using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserTable.Server.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual new ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ApplicationUser()
        {
            Roles = new HashSet<IdentityUserRole<string>>();
        }
    }
}