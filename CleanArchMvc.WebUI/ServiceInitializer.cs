using CleanArchMvc.Domain.Account;

namespace CleanArchMvc.WebUI
{
    public class ServiceInitializer
    {
        public ServiceInitializer(/*IApplicationBuilder app, IWebHostBuilder env,*/ ISeedUserRoleInitial seedUserRoleInitial)
        {
            
        }
        public void Configuration (/*IApplicationBuilder app, IWebHostBuilder env,*/ ISeedUserRoleInitial seedUserRoleInitial)
        {
            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();
        }
    }
}
