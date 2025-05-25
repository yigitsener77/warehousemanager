using Data.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BusinessLogic.Services
{
    public class ApplicationRoleManager : RoleManager<IdentityRole, string>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }

        public static ApplicationRoleManager Instance(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var store = new RoleStore<IdentityRole>(context.Get<DataContext>());
            return new ApplicationRoleManager(store);
        }
    }
}
