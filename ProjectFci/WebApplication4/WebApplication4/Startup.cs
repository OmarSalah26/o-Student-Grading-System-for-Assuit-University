using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebApplication4.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication4.Startup))]
namespace WebApplication4
{
    public partial class Startup
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            //createRole();

        }

        public void createRole()
        {
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!rolemanger.RoleExists("Admin"))
            {
                role = new IdentityRole();
                role.Name = "Admin";
                rolemanger.Create(role);
            }
            if (!rolemanger.RoleExists("ControlAdmin"))
            {
                role = new IdentityRole();
                role.Name = "ControlAdmin";
                rolemanger.Create(role);
            }
            if (!rolemanger.RoleExists("ControlStaff"))
            {
                role = new IdentityRole();
                role.Name = "ControlStaff";
                rolemanger.Create(role);
            }
            if (!rolemanger.RoleExists("StudentAffiers"))
            {
                role = new IdentityRole();
                role.Name = "StudentAffiers";
                rolemanger.Create(role);
            }

        }

    }
}
