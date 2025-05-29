using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.API.Domain.Interfaces.Repositories;
using Sales.API.Infra.Data.Context;
using Sales.API.Infra.Data.Repositories;

namespace Sales.API.CrossCutting.DependencyInjection
{
    public class ConfigureRepositories
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Default"))
            );

            services.AddTransient<IProductRepository, ProductRepositoy>();
            services.AddTransient<IComissionRepository, ComissionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserDapperRepository, UserDapperRepository>();
        }
    }
}
