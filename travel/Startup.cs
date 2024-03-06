﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using travel.Models;

[assembly: OwinStartupAttribute(typeof(travel.Startup))]
namespace travel
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }



        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new
                UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {
                role.Name = "Mohammed";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "3M-A";
                user.LastName = "TEAM";
                user.Email = "HEAR@gmail.com";
                user.UserName = "3M-ATEAM";
                var Check = userManager.Create(user, "TEAM@123");


                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}