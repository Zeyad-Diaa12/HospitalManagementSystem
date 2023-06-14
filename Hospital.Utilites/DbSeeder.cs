using Hospital.Repositories;
using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Utilites
{
    public class DbSeeder : IDbSeeder
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppDbContext _context;

        public DbSeeder(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if(!_roleManager.RoleExistsAsync(Roles.App_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Roles.App_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.App_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Roles.App_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new AppUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                },"Admin@201").GetAwaiter().GetResult();

                var Appuser = _context.AppUsers.FirstOrDefault(x => x.Email == "admin@gmail.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, Roles.App_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}
