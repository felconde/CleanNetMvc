using CleanArchMvc.Domain.Account;
using CleanArchMvc.Infra.IoC;

namespace CleanArchMvc.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ISeedUserRoleInitial seedUserRoleInitial)
        {
            Configuration = configuration;
            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddControllersWithViews();

        }

    }
}
