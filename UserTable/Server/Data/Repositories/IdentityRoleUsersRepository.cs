using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UserTable.Server.Data.Abstract;

namespace UserTable.Server.Data.Repositories
{
    public class IdentityRoleUsersRepository : EntityBaseRepository<IdentityRole>, IIdentityRoleUsersRepository
    {
        public IdentityRoleUsersRepository(Profico_DB_Context context)
            : base(context)
        { }
    }
}