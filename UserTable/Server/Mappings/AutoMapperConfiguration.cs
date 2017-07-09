using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UserTable.Server.Entities;
using UserTable.Server.Models;

namespace UserTable.Server.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<IdentityUserRole<string>, UserRolesVM>();
                config.CreateMap<ApplicationUser, ApplicationUserVM>().ForMember(fm => fm.UserRoles, opts => opts.MapFrom(from => from.Roles));
                config.CreateMap<IdentityRole, IdentityRoleVM>();
            });
        }
    }
}