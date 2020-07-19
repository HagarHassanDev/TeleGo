using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TeleGo.Models;

[assembly: OwinStartup(typeof(TeleGo.Startup))]

namespace TeleGo
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // CreateRole();
        }
        public void CreateRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Buyer"))
            {
                role = new IdentityRole();
                role.Name = "Buyer";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Seller"))
            {
                role = new IdentityRole();
                role.Name = "Seller";
                roleManager.Create(role);
            }
        }
    }
}
