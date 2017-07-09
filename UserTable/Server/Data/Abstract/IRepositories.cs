using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UserTable.Server.Entities;

namespace UserTable.Server.Data.Abstract
{
    public interface IApplicationUsersRepository : IEntityBaseRepository<ApplicationUser> { }

    public interface IIdentityRoleUsersRepository : IEntityBaseRepository<IdentityRole> { }

}