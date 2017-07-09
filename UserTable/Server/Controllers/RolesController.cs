using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UserTable.Server.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserTable.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(
         UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // POST api/roles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddUsersRole clientItem)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var user = await _userManager.FindByIdAsync(clientItem.UserId);
                var role = await _roleManager.FindByIdAsync(clientItem.RoleId);
                if (user != null && role != null)
                {
                    bool userHasRole = await _userManager.IsInRoleAsync(user, role.Name);
                    IdentityResult result = null;

                    if (userHasRole)
                        result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    else
                        result = await _userManager.AddToRoleAsync(user, role.Name);
                   
                    if (result?.Succeeded != null)
                    {
                        
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch 
            {
                // log
                return BadRequest();
            }
        }
    }

    public class AddUsersRole
    {
        [Required]
        [StringLength(68)]
        public string UserId { get; set; }

        [Required]
        [StringLength(68)]
        public string RoleId { get; set; }
    }
}