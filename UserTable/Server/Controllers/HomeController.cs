using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserTable.Server.Data.Abstract;
using UserTable.Server.Entities;
using UserTable.Server.Models;
using UserTable.Server.Models.Helpers;
using UserTable.Server.Models.ViewData;

namespace UserTable.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationUsersRepository _applicationUserRepository;
        private readonly IIdentityRoleUsersRepository _identityUserRepository;

        public HomeController(IApplicationUsersRepository applicationUserRepository, IIdentityRoleUsersRepository identityUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _identityUserRepository = identityUserRepository;
        }

        public IActionResult Index()
        {
            IQueryable<IdentityRole> roles = _identityUserRepository.GetAll();
            IQueryable<ApplicationUser> users = _applicationUserRepository.AllIncluding(inc => inc.Roles);

            IEnumerable<ApplicationUserVM> usersVM = Mapper.Map<IEnumerable<ApplicationUserVM>>(users);
            IEnumerable<IdentityRoleVM> rolesVM = Mapper.Map<IEnumerable<IdentityRoleVM>>(roles);

            UsersWithRolesVM users_roles = new UsersWithRolesVM()
            {
                Users_list = usersVM,
                Roles_list = rolesVM,
                RoleNames = Helpers<IdentityRoleVM>.RoleNamesFn(rolesVM, "Name")
            };
            return View(users_roles);
        }
    }
}