using UserTable.Server.Data.Abstract;
using UserTable.Server.Entities;

namespace UserTable.Server.Data.Repositories
{
    public class ApplicationUserRepository : EntityBaseRepository<ApplicationUser>, IApplicationUsersRepository
    {
        public ApplicationUserRepository(Profico_DB_Context context)
            : base(context)
        { }
    }
}