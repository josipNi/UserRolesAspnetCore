using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserTable.Server.Entities;

namespace UserTable.Server.Data
{
    public class Profico_DB_Context : IdentityDbContext<ApplicationUser>
    {
        public Profico_DB_Context(DbContextOptions<Profico_DB_Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}