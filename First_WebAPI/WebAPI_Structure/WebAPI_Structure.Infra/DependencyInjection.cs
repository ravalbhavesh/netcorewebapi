using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_Structure.Core.Models;
using WebAPI_Structure.Infra.Services.Products;
using WebAPI_Structure.Infra.Services.UserAdmin;

namespace WebAPI_Structure.Infra
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSqlServer<DemoDBContext>(Configuration.GetConnectionString("DefaultConnection"));
            services.AddTransient<IProductsServices, ProductsServices>();
            services.AddTransient<IUserAdminServices, UserAdminServices>();
            return services;
        }

    }
}