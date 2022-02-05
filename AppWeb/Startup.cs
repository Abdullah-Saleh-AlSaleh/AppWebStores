using AppWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppWeb.Startup))]
namespace AppWeb
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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Abdalla.aa5517@gmail.com";
                user.FullName = "Abdullah AlSaleh";
                user.PhoneNumber = "966548010499";
                var Check = userManager.Create(user, "Ab/*-+987");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
            }

        }

    }
}
